using System.Collections.Generic;
using System.Threading.Tasks;
using PB.Core.Models;

namespace PB.Core.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        Task<Category> GetAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category Category);
        Task UpdateAsync(int id);
        Task RemoveAsync(int id);
    }
}