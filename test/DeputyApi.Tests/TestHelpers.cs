using System.Net.Http;
using System.Net.Http.Headers;

namespace DeputyApi.Tests
{
    public static class TestHelpers
    {
        public static readonly DeputyOptions TestOptions = new DeputyOptions("mysubdomain.au.deputy.com", "v1");
    }
}
