using System.Threading.Tasks;
using PB.Infrastucture.DTO;

namespace PB.Infrastucture.Services
{
    public interface IUserService : IService
    {
         Task RegisterAsync(string email, string password, string username);
         Task<UserDTO> LoginAsync(string email);
    }
}