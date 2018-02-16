using System.Net.Http;
using System.Net.Http.Headers;

namespace DeputyApi.Tests
{
    public static class TestHelpers
    {
        public static readonly DeputyOptions TestOptions = new DeputyOptions("mysubdomain", "au", "v1");

        internal static bool VerifyAuthorizationHeader(HttpRequestMessage request, AuthenticationHeaderValue expectedValue)
            => request.Headers.Authorization.Equals(expectedValue);
    }
}
