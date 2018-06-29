using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PB.Infrastucture.Commands;
using PB.Infrastucture.Commands.User;
using PB.Infrastucture.Extenstions;

namespace PB.Api.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IMemoryCache _cache;
        public LoginController(ICommandDispatcher commandDispatcher,
            IMemoryCache cache) 
            : base(commandDispatcher)
        {
            _cache = cache;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]LoginUser command)
        {
            command.TokenId = Guid.NewGuid();
            await DispatchAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }
    }
}