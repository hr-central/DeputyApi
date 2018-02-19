using System.Net.Http;
using System.Threading.Tasks;
using DeputyApi.Models;
using Xunit;

namespace DeputyApi.Tests.Employee
{
    [Trait("Category", "API")]
    [Trait("Endpoint", "Put Employees")]
    [Trait("Resource", "Employee")]
    public class PutEmployeeTests : EndpointTestHarness
    {
        protected override HttpResponseMessage TestResponse => new HttpResponseMessage { Content = new StringContent(@"{}") };

        protected override HttpMethod ExpectedMethod => HttpMethod.Put;

        protected override string ExpectedEndpoint => "resource/Employee";

        protected override async Task InvokeClient() => await _deputyClient.Employees.CreateAsync(new EmployeeModel());
    }
}
