using AutoMapper;
using PB.Core.Models;
using PB.Infrastucture.DTO;

namespace PB.Infrastucture.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                cfg.CreateMap<User, UserDTO>())
            .CreateMapper();
    }
}