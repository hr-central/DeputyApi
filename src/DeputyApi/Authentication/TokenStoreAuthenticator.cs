using System.Threading.Tasks;

namespace DeputyApi.Authentication
{
    public class TokenStoreAuthenticator : IAuthenticator
    {
        private readonly ITokenStore _tokenStore;

        public TokenStoreAuthenticator(ITokenStore tokenStore)
        {
            _tokenStore = tokenStore;
        }

        public virtual async Task<string> GetAccessTokenAsync()
        {
            var token = await _tokenStore.GetTokenAsync();
            return token.AccessToken;
        }
    }
}
