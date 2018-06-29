using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PB.Core.Models;

namespace PB.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(string email);
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(Guid id);
    }
}