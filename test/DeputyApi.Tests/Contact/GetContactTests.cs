using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DeputyApi.Tests
{
    [Trait("Category", "API")]
    [Trait("Endpoint", "Get Contact")]
    [Trait("Resource", "Contact")]
    public class GetContactTests : EndpointTestHarness
    {
        protected override HttpResponseMessage TestResponse => new HttpResponseMessage { Content = new StringContent(@"{}") };

        protected override string ExpectedEndpoint => "resource/Contact/101";

        protected override HttpMethod ExpectedMethod => HttpMethod.Get;

        protected override async Task InvokeClient() => await _deputyClient.Contacts.GetByIdAsync(101);
    }
}
