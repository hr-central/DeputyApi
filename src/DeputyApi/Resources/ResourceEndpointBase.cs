using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DeputyApi.Authentication;
using DeputyApi.Models;
using DeputyApi.Serialization;
using DeputyApi.Transport;

namespace DeputyApi.Resources
{
    internal abstract class ResourceEndpointBase<T, TKey> : IResourceEndpoint<T, TKey>
    {
        private readonly IAuthenticator _authenticator;
        private readonly IHttpClient _httpClient;
        private readonly JsonSerializer _serializer;

        public ResourceEndpointBase(IAuthenticator authenticator, IHttpClient httpClient, JsonSerializer serializer)
        {
            _authenticator = authenticator;
            _httpClient = httpClient;
            _serializer = serializer;
        }

        public virtual async Task<T> CreateAsync(T model)
        {
            var body = _serializer.Serialize(model);
            var response = await _httpClient.MakeRequestAsync(HttpMethod.Put, $"resource/{ResourceName}", headers: await GetAuthHeaderDictionary());
            await HandleError(response);
            return _serializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var response = await _httpClient.MakeRequestAsync(HttpMethod.Delete, $"resource/{ResourceName}/{id}", headers: await GetAuthHeaderDictionary());
            await HandleError(response);
        }

        public virtual async Task<T> GetByIdAsync(TKey id)
        {
            var response = await _httpClient.MakeRequestAsync(HttpMethod.Get, $"resource/{ResourceName}/{id}", headers: await GetAuthHeaderDictionary());
            await HandleError(response);
            return _serializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<IEnumerable<T>> GetListAsync()
        {
            var response = await _httpClient.MakeRequestAsync(HttpMethod.Get, $"resource/{ResourceName}", headers: await GetAuthHeaderDictionary());
            await HandleError(response);
            return _serializer.Deserialize<IEnumerable<T>>(await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<T> UpdateAsync(TKey id, T model)
        {
            var body = _serializer.Serialize(model);
            var response = await _httpClient.MakeRequestAsync(HttpMethod.Post, $"resource/{ResourceName}/{id}", headers: await GetAuthHeaderDictionary());
            await HandleError(response);
            return _serializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
        }

        protected abstract string ResourceName { get; }

        private async Task<IDictionary<string, string>> GetAuthHeaderDictionary()
        {
            var token = await _authenticator.GetAccessTokenAsync();
            return new Dictionary<string, string>
            {
                { "Authorization", "Bearer " + token }
            };
        }

        private async Task HandleError(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var errorModel = _serializer.Deserialize<ErrorContainerModel>(await response.Content.ReadAsStringAsync());
                throw new DeputyApiException(response.StatusCode, errorModel.Error.Code, errorModel.Error.Message);
            }
        }
    }
}
