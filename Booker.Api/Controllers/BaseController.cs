using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
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