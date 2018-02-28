using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DeputyApi.Authentication
{
    public class TokenStoreAuthenticator : IAuthenticator
    {
        private readonly ITokenStore _tokenStore;
        private readonly IClient _client;
        private readonly DeputyOptions _options;

        public TokenStoreAuthenticator(ITokenStore tokenStore, IClient client, DeputyOptions options)
        {
            _tokenStore = tokenStore;
            _client = client;
            _options = options;
        }

        public virtual async Task<string> GetAccessTokenAsync()
        {
            var token = await _tokenStore.GetTokenAsync();
            if (token.HasExpired())
            {
                token = await RefreshTokenAsync(token);
                await _tokenStore.SaveTokenAsync(token);
            }

            return token.AccessToken;
        }

        protected virtual async Task<IToken> RefreshTokenAsync(IToken token)
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "client_id", _client.Id },
                    { "client_secret", _client.Secret },
                    { "redirect_uri", _client.RedirectUri },
                    { "grant_type", "refresh_token" },
                    { "refresh_token", token.RefreshToken },
                    { "scope", "longlife_refresh_token" }
                });
                var refreshResult = await client.PostAsync(GetRefreshUri(_options), content);
                if (!refreshResult.IsSuccessStatusCode)
                    throw new InvalidOperationException("Failed to refresh the access token.");

                return UnpackToken(await refreshResult.Content.ReadAsStringAsync());
            }
        }

        private IToken UnpackToken(string tokenString)
        {
            var jobj = JObject.Parse(tokenString);
            return new Token(
                accessToken: jobj["access_token"].ToString(),
                refreshToken: jobj["refresh_token"].ToString(),
                issuedAt: DateTime.UtcNow,
                expiresIn: TimeSpan.FromSeconds(jobj["expires_in"].ToObject<int>()));
        }

        private static string GetRefreshUri(DeputyOptions options) => $"https://{options.Subdomain}.{options.Region}.deputy.com/oauth/access_token";
    }
}
