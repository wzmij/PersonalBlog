using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PB.Infrastucture.Commands;
using PB.Infrastucture.Commands.User;
using PB.Infrastucture.Extenstions;
using PB.Infrastucture.Services;

namespace PB.Infrastucture.Handlers.User
{
    public class LoginUserHandler : ICommandHandler<LoginUser>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginUserHandler(IUserService userService, IJwtHandler jwtHandler, IMemoryCache cache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandleAsync(LoginUser command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
            var user = await _userService.GetAsync(command.Email);
            var jwt = _jwtHandler.CreateToken(command.Email);

            _cache.SetJwt(command.TokenId, jwt);
        }
    }
}