using System;
using System.Threading.Tasks;
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
        protected LoginController(ICommandDispatcher commandDispatcher, IMemoryCache cache) : base(commandDispatcher)
        {
            _cache = cache;
        }

        public async Task<IActionResult> Post(LoginUser command)
        {
            command.TokenId = Guid.NewGuid();
            await _commandDispatcher.DispatchAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }
    }
}