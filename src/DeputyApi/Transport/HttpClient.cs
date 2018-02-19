using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using NetHttpClient = System.Net.Http.HttpClient;

namespace DeputyApi.Transport
{
    internal class HttpClient : IHttpClient
    {
        private readonly NetHttpClient _client = new NetHttpClient();
        private readonly string _baseUri;

        public HttpClient(string baseUri)
        {
            _baseUri = baseUri;
        }

        public async Task<HttpResponseMessage> MakeRequestAsync(HttpMethod method, string path, IDictionary<string, string> query = null, IDictionary<string, string> headers = null, string body = null)
        {
            var requestUri = BuildUri(path, query);
            var request = new HttpRequestMessage(method, requestUri);
            CopyHeaders(headers, request);
            return await _client.SendAsync(request);
        }

        private string BuildUri(string uri, object query) =>
            _baseUri
            .AppendPathSegment(uri)
            .SetQueryParams(query)
            .ToString();

        private static void CopyHeaders(IDictionary<string, string> headers, HttpRequestMessage request)
        {
            if (headers == null)
                return;

            foreach (var item in headers)
                request.Headers.Add(item.Key, item.Value);
        }
    }
}
