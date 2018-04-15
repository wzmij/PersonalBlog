using System.Collections.Generic;
using System.Threading.Tasks;
using PB.Core.Models;

namespace PB.Core.Repositories
{
    public interface IPostRepository : IRepository
    {
        Task<Post> GetAsync(int id);
        Task<IEnumerable<Post>> GetAllAsync();
        Task AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task RemoveAsync(int id);
    }
}