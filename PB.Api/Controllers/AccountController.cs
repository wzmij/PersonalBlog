using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PB.Infrastucture.Commands;
using PB.Infrastucture.Services;

namespace PB.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IJwtHandler _jwtHandler;
        public AccountController(ICommandDispatcher commandDispatcher, IJwtHandler jwtHandler) : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpGet("token")]
        public async Task<IActionResult> Get()
        {
            var token = _jwtHandler.Create("user@test.pl");

            return Json(token);
        }

        [HttpGet("auth")]
        public async Task<IActionResult> GetAuth()
        {
            return Content("Auth ok");
        }
    }
}