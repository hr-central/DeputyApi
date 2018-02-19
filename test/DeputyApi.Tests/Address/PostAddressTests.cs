using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using DeputyApi.Models;

namespace DeputyApi.Tests
{
    [Trait("Category", "API")]
    [Trait("Endpoint", "Post Address")]
    [Trait("Resource", "Address")]
    public class PostAddressTests : EndpointTestHarness
    {
        protected override HttpResponseMessage TestResponse => new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(@"{}") };

        protected override string ExpectedEndpoint => "resource/Address/101";

        protected override HttpMethod ExpectedMethod => HttpMethod.Post;

        protected override async Task InvokeClient() => await _deputyClient.Addresses.UpdateAsync(101, new AddressModel());
    }
}
