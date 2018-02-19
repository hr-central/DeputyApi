using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DeputyApi.Tests.Employee
{
    [Trait("Category", "API")]
    [Trait("Endpoint", "Get Employees")]
    [Trait("Resource", "Employee")]
    public class GetEmployeeTests : EndpointTestHarness
    {
        protected override HttpResponseMessage TestResponse => new HttpResponseMessage { Content = new StringContent(@"{}") };

        protected override string ExpectedEndpoint => "resource/Employee/101";

        protected override HttpMethod ExpectedMethod => HttpMethod.Get;

        protected override async Task InvokeClient() => await _deputyClient.Employees.GetByIdAsync(101);
    }
}
