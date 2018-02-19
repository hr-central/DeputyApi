using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeputyApi.Transport
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> MakeRequestAsync(HttpMethod method, string path, IDictionary<string, string> query = null, IDictionary<string, string> headers = null, string body = null);
    }
}
