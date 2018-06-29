using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PB.Core.Models;
using PB.Core.Repositories;

namespace PB.Infrastucture.Repositories
{
    public class MemoryCategoryRepository : ICategoryRepository
    {
        private readonly ISet<Category> _categories = new HashSet<Category>();

        public async Task AddAsync(Category category)
            => await Task.FromResult(_categories.Add(category));

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await Task.FromResult(_categories);

        public async Task<Category> GetAsync(int id)
            => await Task.FromResult(_categories.SingleOrDefault(x => x.Id == id));

        public async Task RemoveAsync(int id)
        {
            var category = await GetAsync(id);

            if(category == null)
            {
                throw new Exception("Category don't exist");
            }

            _categories.Remove(category);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(int id)
        {
            await Task.CompletedTask;
        }
    }
}