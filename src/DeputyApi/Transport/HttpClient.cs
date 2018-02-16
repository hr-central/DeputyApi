using System.Net.Http;
using System.Threading.Tasks;
using NetHttpClient = System.Net.Http.HttpClient;

namespace DeputyApi.Transport
{
    internal class HttpClient : IHttpClient
    {
        private readonly NetHttpClient _client = new NetHttpClient();

        public async Task<HttpResponseMessage> MakeRequestAsync(HttpRequestMessage request)
            => await _client.SendAsync(request);
    }
}
