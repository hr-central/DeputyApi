using System.Threading.Tasks;
using DeputyApi.Models;
using DeputyApi.Resources;

namespace DeputyApi
{
    public interface IDeputyClient
    {
        Task<UserModel> GetMeAsync();
        IResourceEndpoint<ContactModel, int> Contacts { get; }
        IResourceEndpoint<EmployeeModel, int> Employees { get; }
    }
}
