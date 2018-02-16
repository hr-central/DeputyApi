using System.Threading.Tasks;

namespace DeputyApi.Authentication
{
    public interface IAuthenticator
    {
        Task<string> GetAccessTokenAsync();
    }
}
