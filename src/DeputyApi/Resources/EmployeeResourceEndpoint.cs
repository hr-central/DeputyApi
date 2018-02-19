using DeputyApi.Authentication;
using DeputyApi.Models;
using DeputyApi.Serialization;
using DeputyApi.Transport;

namespace DeputyApi.Resources
{
    internal class EmployeeResourceEndpoint : ResourceEndpointBase<EmployeeModel, int>
    {
        public EmployeeResourceEndpoint(IAuthenticator authenticator, IHttpClient httpClient, JsonSerializer serializer)
            : base(authenticator, httpClient, serializer)
        {
        }

        protected override string ResourceName => "Employee";
    }
}
