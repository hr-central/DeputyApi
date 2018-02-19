using DeputyApi.Authentication;
using DeputyApi.Models;
using DeputyApi.Serialization;
using DeputyApi.Transport;

namespace DeputyApi.Resources
{
    internal class ContactResourceEndpoint : ResourceEndpointBase<ContactModel, int>
    {
        public ContactResourceEndpoint(IAuthenticator authenticator, IHttpClient httpClient, JsonSerializer serializer)
            : base(authenticator, httpClient, serializer)
        {
        }

        protected override string ResourceName => "Contact";
    }
}
