using System;
using System.Threading.Tasks;
using PB.Core.Models;
using PB.Core.Repositories;

namespace PB.Infrastucture.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository, ICategoryRepository categoryRepository)
        {
            _postRepository = postRepository;
        }

        public async Task Create(string header, string body, int categoryId, Guid userId)
        {
            var post = new Post(header, body, userId, categoryId);
            await _postRepository.AddAsync(post);
        }
    }
}