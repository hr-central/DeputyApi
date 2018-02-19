using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeputyApi.Resources
{
    public interface IResourceEndpoint<T, TKey>
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T> GetByIdAsync(TKey id);
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(TKey id, T model);
        Task DeleteAsync(TKey id);
    }
}
