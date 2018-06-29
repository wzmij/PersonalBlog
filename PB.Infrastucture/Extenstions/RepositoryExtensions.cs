using System;
using System.Threading.Tasks;
using PB.Core.Models;
using PB.Core.Repositories;

namespace PB.Infrastucture.Extenstions
{
    public static class RepositoryExtensions
    {
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, string email)
        {
            var user = await repository.GetAsync(email);
            if(user == null)
            {
                throw new Exception("User with this email doesn't exist.");
            }

            return user;
        }
    }
}