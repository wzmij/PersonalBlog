using System;
using System.Threading.Tasks;
using PB.Infrastucture.DTO;

namespace PB.Infrastucture.Services
{
    public interface IUserService : IService
    {
        Task<UserDTO> GetAsync(string email);
        Task RegisterAsync(Guid userId ,string email, string password, string username);
        Task LoginAsync(string email, string password);

    }
}