using System;
using PB.Infrastucture.DTO;

namespace PB.Infrastucture.Services
{
    public interface IJwtHandler
    {
        JwtDTO CreateToken(Guid userId);
    }
}