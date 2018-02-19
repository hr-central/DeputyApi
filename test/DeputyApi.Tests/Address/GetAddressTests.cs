using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DeputyApi.Tests
{
    [Trait("Category", "API")]
    [Trait("Endpoint", "Get Address")]
    [Trait("Resource", "Address")]
    public class GetAddressTests : EndpointTestHarness
    {
        protected override HttpResponseMessage TestResponse => new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(@"{}") };

        protected override string ExpectedEndpoint => "resource/Address/101";

        protected override HttpMethod ExpectedMethod => HttpMethod.Get;

        protected override async Task InvokeClient() => await _deputyClient.Addresses.GetByIdAsync(101);
    }
}
