using System.Web.Http;
using Booker.Infrastructure.Commands;

namespace Booker.Api.Controllers
{
    public abstract class BaseController : ApiController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        protected BaseController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
    }
}