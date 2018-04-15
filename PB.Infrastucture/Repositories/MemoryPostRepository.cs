using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PB.Core.Models;
using PB.Core.Repositories;

namespace PB.Infrastucture.Repositories
{
    public class MemoryPostRepository : IPostRepository
    {
        private readonly ISet<Post> _posts = new HashSet<Post>();
        public async Task AddAsync(Post post)
            => await Task.FromResult(_posts.Add(post));

        public async Task<IEnumerable<Post>> GetAllAsync()
            => await Task.FromResult(_posts);
        public async Task<Post> GetAsync(int id)
            => await Task.FromResult(_posts.SingleOrDefault(x => x.Id == id));
        public async Task RemoveAsync(int id)
        {
            var post = await GetAsync(id);

            if(post == null)
            {
                throw new Exception("User don't exist");
            }

            _posts.Remove(post);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Post Post)
        {
            await Task.CompletedTask;
        }
    }
}