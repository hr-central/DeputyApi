using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Moq;
using Xunit;
using DeputyApi.Authentication;
using DeputyApi.Transport;

namespace DeputyApi.Tests
{
    [Trait("Category", "API")]
    [Trait("Endpoint", "Get Me")]
    public class GetMeTests
    {
        private static readonly HttpResponseMessage TestResponse = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(@"{""Name"":""Test Person""}")
        };

        private readonly IAuthenticator _authenticator;
        private readonly Mock<IHttpClient> _httpMock;
        private readonly DeputyClient _deputyClient;

        public GetMeTests()
        {
            var authMock = new Mock<IAuthenticator>();
            authMock.Setup(a => a.GetAccessTokenAsync()).ReturnsAsync("some_token");
            _authenticator = authMock.Object;

            _httpMock = new Mock<IHttpClient>();
            _httpMock.Setup(h => h.MakeRequestAsync(
                HttpMethod.Get,
                "me",
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<string>())).ReturnsAsync(TestResponse);

            _deputyClient = new DeputyClient(_authenticator, TestHelpers.TestOptions)
            {
                HttpClient = _httpMock.Object
            };
        }

        [Fact]
        public async Task Includes_Authorization_Token()
        {
            await _deputyClient.GetMeAsync();

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
            await _deputyClient.GetMeAsync();

            _httpMock.Verify(h => h.MakeRequestAsync(
                It.Is<HttpMethod>(m => m == HttpMethod.Get),
                It.Is<string>(p => p.Equals("me")),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<string>()),
                Times.Once);
        }
    }
}
