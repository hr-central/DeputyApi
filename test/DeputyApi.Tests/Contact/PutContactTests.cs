using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using DeputyApi.Models;

namespace DeputyApi.Tests
{
    [Trait("Category", "API")]
    [Trait("Endpoint", "Put Contact")]
    [Trait("Resource", "Contact")]
    public class PutContactTests : EndpointTestHarness
    {
        protected override HttpResponseMessage TestResponse => new HttpResponseMessage { Content = new StringContent(@"{}") };

        protected override string ExpectedEndpoint => "resource/Contact";

        protected override HttpMethod ExpectedMethod => HttpMethod.Put;

        protected override async Task InvokeClient() => await _deputyClient.Contacts.CreateAsync(new ContactModel());
    }
}
