using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DeputyApi.Authentication;
using DeputyApi.Transport;
using Moq;
using Xunit;

namespace DeputyApi.Tests
{
    public abstract class EndpointTestHarness
    {
        private readonly IAuthenticator _authenticator;

        protected readonly Mock<IHttpClient> _httpMock;
        protected readonly DeputyClient _deputyClient;

        public EndpointTestHarness()
        {
            var authMock = new Mock<IAuthenticator>();
            authMock.Setup(a => a.GetAccessTokenAsync()).ReturnsAsync("some_token");
            _authenticator = authMock.Object;

            _httpMock = new Mock<IHttpClient>();
            _httpMock.Setup(h => h.MakeRequestAsync(
                It.IsAny<HttpMethod>(),
                It.IsAny<string>(),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<string>())).ReturnsAsync(TestResponse);

            _deputyClient = new DeputyClient(_authenticator, TestHelpers.TestOptions, _httpMock.Object);
        }

        [Fact]
        public async Task Includes_Authorization_Header()
        {
            await InvokeClient();

            _httpMock.Verify(h => h.MakeRequestAsync(
                It.IsAny<HttpMethod>(),
                It.IsAny<string>(),
                It.IsAny<IDictionary<string, string>>(),
                It.Is<IDictionary<string, string>>(headers => headers["Authorization"] == "Bearer some_token"),
                It.IsAny<string>()),
                Times.Once);
        }

        [Fact]
        public async Task Requests_Correct_Endpoint()
        {
            await InvokeClient();

            _httpMock.Verify(h => h.MakeRequestAsync(
                It.Is<HttpMethod>(m => m == HttpMethod.Get),
                It.Is<string>(s => s.Equals(ExpectedEndpoint)),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<string>()),
                Times.Once);
        }

        protected abstract Task InvokeClient();
        protected abstract HttpResponseMessage TestResponse { get; }
        protected abstract string ExpectedEndpoint { get; }
    }
}
