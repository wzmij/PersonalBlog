using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PB.Infrastucture.Commands;
using PB.Infrastucture.Commands.User;
using PB.Infrastucture.Services;

namespace PB.Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);

            if(user == null)
            {
                return NoContent();
            }

            return Json(user);
        }

        [AllowAnonymous]
        [HttpPost("")]
        public async Task<IActionResult> Put([FromBody]CreateUser command)
        {
            await DispatchAsync(command);

            return Created($"users/{command.Email}", null);
        }
    }
}