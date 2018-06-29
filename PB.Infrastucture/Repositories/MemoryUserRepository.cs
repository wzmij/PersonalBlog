using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PB.Core.Models;
using PB.Core.Repositories;

namespace PB.Infrastucture.Repositories
{
    public class MemoryUserRepository : IUserRepository
    {
        private readonly ISet<User> _users = new HashSet<User>();

        public MemoryUserRepository()
        {
            _users.Add(new User(Guid.NewGuid() ,"test", "test@o2.pl", "test", "test", Roles.Admin));
        }

        public async Task AddAsync(User user)
            => await Task.FromResult(_users.Add(user));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);

            if(user == null)
            {
                throw new Exception("User don't exist");
            }

            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
