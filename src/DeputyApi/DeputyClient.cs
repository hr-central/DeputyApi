using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DeputyApi.Authentication;
using DeputyApi.Models;
using DeputyApi.Serialization;
using DeputyApi.Transport;

namespace DeputyApi
{
    public class DeputyClient : IDeputyClient
    {
        private readonly IAuthenticator _authenticator;
        private readonly DeputyOptions _options;
        private readonly JsonSerializer _serializer = new JsonSerializer();

        public DeputyClient(IAuthenticator authenticator, DeputyOptions options)
        {
            _authenticator = authenticator;
            _options = options;
            HttpClient = new Transport.HttpClient(GetBaseUri(options));
        }

        public IHttpClient HttpClient { get; set; }

        public async Task<UserModel> GetMeAsync()
        {
            var token = await _authenticator.GetAccessTokenAsync();
            var headers = new Dictionary<string, string>() { { "Authorization", "Bearer " + token } };
            var response = await _httpClient.MakeRequestAsync(HttpMethod.Get, "me", headers: headers);
            var responseBody = await response.Content.ReadAsStringAsync();
            return _serializer.Deserialize<UserModel>(responseBody);
        }

        private static string GetBaseUri(DeputyOptions options) => $"https://{options.Subdomain}.{options.Region}.deputy.com/api/{options.ApiVersion}";
    }
}
