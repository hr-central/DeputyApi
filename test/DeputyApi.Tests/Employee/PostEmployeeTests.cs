using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using DeputyApi.Models;

namespace DeputyApi.Tests.Employee
{
    [Trait("Category", "API")]
    [Trait("Endpoint", "Get Employees")]
    [Trait("Resource", "Employee")]
    public class PostEmployeeTests : EndpointTestHarness
    {
        protected override HttpResponseMessage TestResponse => new HttpResponseMessage { Content = new StringContent(@"{}") };

        protected override string ExpectedEndpoint => "resource/Employee/101";

        protected override HttpMethod ExpectedMethod => HttpMethod.Post;

        protected override async Task InvokeClient() => await _deputyClient.Employees.UpdateAsync(101, new EmployeeModel());
    }
}
