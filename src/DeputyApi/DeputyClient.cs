using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Flurl;
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
        }

        public IHttpClient HttpClient { get; set; } = new Transport.HttpClient();

        public async Task<UserModel> GetMeAsync()
        {
            var response = await MakeRequest(HttpMethod.Get, "me");
            var responseBody = await response.Content.ReadAsStringAsync();
            return _serializer.Deserialize<UserModel>(responseBody);
        }

        private async Task<HttpResponseMessage> MakeRequest(HttpMethod method, string uri, object query = null)
        {
            var requestUri = BuildUri(uri, query);
            var request = new HttpRequestMessage(method, requestUri);
            var token = await _authenticator.GetAccessTokenAsync();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await HttpClient.MakeRequestAsync(request);
        }

        private string BuildUri(string uri, object query) =>
            GetBaseUri(_options)
            .AppendPathSegment(uri)
            .SetQueryParams(query)
            .ToString();

        private Url GetBaseUri(DeputyOptions options)
            => new Url($"https://{options.Subdomain}.{options.Region}.deputy.com/api/{options.ApiVersion}");
    }
}
