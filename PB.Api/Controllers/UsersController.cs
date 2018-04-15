using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PB.Infrastucture.Commands;
using PB.Infrastucture.Commands.User;
using PB.Infrastucture.Services;

namespace PB.Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        public UsersController(ICommandDispatcher commandDispatcher, IUserService userService) : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.LoginAsync(email);

            if(user == null)
            {
                return NoContent();
            }

            return Json(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> Put([FromBody]CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Created($"users/{command.Email}", null);
        }
    }
}