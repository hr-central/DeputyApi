using System.Threading.Tasks;

namespace DeputyApi.Authentication
{
    public interface ITokenStore
    {
        Task<IToken> GetTokenAsync();
        Task SaveTokenAsync(IToken token);
    }
}
