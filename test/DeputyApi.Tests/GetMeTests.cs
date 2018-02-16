using System;
using System.Net.Http;
using System.Net.Http.Headers;
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
        private static readonly AuthenticationHeaderValue ExpectedAuthorizationHeader = new AuthenticationHeaderValue("Bearer", "some_token");
        private static readonly Uri ExpectedEndpoint = new Uri("https://mysubdomain.au.deputy.com/api/v1/me");
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
            _httpMock.Setup(h => h.MakeRequestAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(TestResponse);

            _deputyClient = new DeputyClient(_authenticator, TestHelpers.TestOptions)
            {
                HttpClient = _httpMock.Object
            };
        }

        [Fact]
        public async Task Get_Me_Includes_Authentication_Token()
        {
            await _deputyClient.GetMeAsync();

            _httpMock.Verify(h => h
                .MakeRequestAsync(It.Is<HttpRequestMessage>(r => TestHelpers.VerifyAuthorizationHeader(r, ExpectedAuthorizationHeader))),
                Times.Once);
        }

        [Fact]
        public async Task Get_Me_Requests_Correct_Endpoint()
        {
            await _deputyClient.GetMeAsync();

            _httpMock.Verify(h => h
                .MakeRequestAsync(It.Is<HttpRequestMessage>(r => r.RequestUri == ExpectedEndpoint)),
                Times.Once);
        }
    }
}
