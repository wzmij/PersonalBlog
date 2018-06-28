using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Get()
        {
            var token = _jwtHandler.CreateToken("test@o2.pl");

            return Json(token);
        }
    }
}