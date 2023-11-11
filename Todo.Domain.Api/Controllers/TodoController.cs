using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody]CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "Pedro";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}