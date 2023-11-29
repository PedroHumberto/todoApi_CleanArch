using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        
        [Route("create")]
        [HttpPost]
        public GenericCommandResult Create([FromBody]CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            if(ModelState.IsValid){
                
                try{

                    command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id").Value;
                }catch{

                    return new GenericCommandResult(false, "User Claims nulll", ModelState);
                }

                return (GenericCommandResult)handler.Handle(command);
            }
            return new GenericCommandResult(false, "Model State Invalid", ModelState);
        }
        [ResponseCache]
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAll(user);
        }

        [HttpGet("done")]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAllDone(user);
        }

        [HttpGet("undone")]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetAllUndone(user);
        }
        
        [HttpGet("done-for-today")]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, DateTime.UtcNow.Date, true);
        }

        [HttpGet("undone")]
        public IEnumerable<TodoItem> GetUndoneForToday([FromServices] ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, DateTime.UtcNow.Date, false);
        }

        [HttpGet("done-for-tomorrow")]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.GetByPeriod(user, DateTime.UtcNow.Date.AddDays(1), true);
        }

        [HttpPut("update")]
        public GenericCommandResult Update([FromBody]UpdateTodoCommand command, [FromServices] TodoHandler handler)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut("mark-as-done")]
        public GenericCommandResult MarkAsDone([FromBody]MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut("mark-as-undone")]
        public GenericCommandResult MarkAsUndone([FromBody]MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler)
        {   
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}