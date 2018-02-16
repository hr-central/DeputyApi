using System.Net.Http;
using System.Threading.Tasks;

namespace DeputyApi.Transport
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> MakeRequestAsync(HttpRequestMessage request);
    }
}
