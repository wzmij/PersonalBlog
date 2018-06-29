using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PB.Infrastucture.Commands;

namespace PB.Api.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) 
            : Guid.Empty; 

        protected ApiController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command is IAuthenticatedCommand authenticatedCommand)
            {
                authenticatedCommand.UserId = UserId;
            }

            await _commandDispatcher.DispatchAsync(command);
        }
    }
}