using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using DeputyApi.Models;

namespace DeputyApi.Tests
{
    [Trait("Category", "API")]
    [Trait("Endpoint", "Post Contact")]
    [Trait("Resource", "Contact")]
    public class PostContactTests : EndpointTestHarness
    {
        protected override HttpResponseMessage TestResponse => new HttpResponseMessage { Content = new StringContent(@"{}") };

        protected override string ExpectedEndpoint => "resource/Contact/101";

        protected override HttpMethod ExpectedMethod => HttpMethod.Post;

        protected override async Task InvokeClient() => await _deputyClient.Contacts.UpdateAsync(101, new ContactModel());
    }
}
