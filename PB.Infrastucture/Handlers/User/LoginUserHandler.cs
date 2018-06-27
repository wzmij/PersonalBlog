using System.Threading.Tasks;
using PB.Infrastucture.Commands;
using PB.Infrastucture.Commands.User;
using PB.Infrastucture.Services;

namespace PB.Infrastucture.Handlers.User
{
    public class LoginUserHandler : ICommandHandler<LoginUser>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;

        public LoginUserHandler(IUserService userService, IJwtHandler jtwHandler)
        {
            _userService = userService;
            _jwtHandler = JwtHandler;
        }

        public Task HandleAsync(LoginUser command)
        {
            throw new System.NotImplementedException();
        }
    }
}