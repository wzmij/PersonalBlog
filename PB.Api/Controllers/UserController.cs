using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PB.Infrastucture.Services;

namespace PB.Api.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
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
    }
}