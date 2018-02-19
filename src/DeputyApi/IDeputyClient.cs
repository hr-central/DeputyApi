using System.Threading.Tasks;
using DeputyApi.Models;
using DeputyApi.Resources;

namespace DeputyApi
{
    public interface IDeputyClient
    {
        Task<UserModel> GetMeAsync();
        IResourceEndpoint<EmployeeModel, int> Employees { get; }
    }
}
