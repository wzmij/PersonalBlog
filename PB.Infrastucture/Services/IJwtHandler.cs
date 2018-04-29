using PB.Infrastucture.DTO;

namespace PB.Infrastucture.Services
{
    public interface IJwtHandler
    {
        JwtDTO Create(string email);
    }
}