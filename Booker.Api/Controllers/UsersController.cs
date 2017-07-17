using System.Collections.Generic;
using System.Web.Http;
using Booker.Infrastructure.Commands;
using Booker.Infrastructure.Commands.Users;
using Booker.Infrastructure.Services;

namespace Booker.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;

        public UsersController(IUserService userService, 
            ICommandDispatcher commandDispatcher) :base(commandDispatcher)
        {
            _userService = userService;
            _commandDispatcher = commandDispatcher;
        }

        // GET: api/Users
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        public async void Post([FromBody]CreateUserCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
