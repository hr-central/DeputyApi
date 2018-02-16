using System.Threading.Tasks;
using DeputyApi.Models;

namespace DeputyApi
{
    public interface IDeputyClient
    {
        Task<UserModel> GetMeAsync();
    }
}
