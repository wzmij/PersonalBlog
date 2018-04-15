using Microsoft.AspNetCore.Mvc;
using PB.Infrastucture.Commands;

namespace PB.Api.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {
        protected readonly ICommandDispatcher _commandDispatcher;

        protected ApiController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
    }
}