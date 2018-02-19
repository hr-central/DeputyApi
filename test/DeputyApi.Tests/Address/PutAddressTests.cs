using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using DeputyApi.Models;

namespace DeputyApi.Tests
{
    [Trait("Category", "API")]
    [Trait("Endpoint", "Put Address")]
    [Trait("Resource", "Address")]
    public class PutAddressTests : EndpointTestHarness
    {
        protected override HttpResponseMessage TestResponse => new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(@"{}") };

        protected override string ExpectedEndpoint => "resource/Address";

        protected override HttpMethod ExpectedMethod => HttpMethod.Put;

        protected override async Task InvokeClient() => await _deputyClient.Addresses.CreateAsync(new AddressModel());
    }
}
