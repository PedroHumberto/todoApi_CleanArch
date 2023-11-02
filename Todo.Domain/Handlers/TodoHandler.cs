using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : 
        Notifiable<Notification>,
        IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if(!command.IsValid){
                return new GenericCommandResult(false, "Wrong Task", command.Notifications);
            }

            // Gerar o TodoItem
            TodoItem todo = new TodoItem(command.Title, command.Date, command.User);

            // Salvar no Banco
            _repository.Create(todo);

            return new GenericCommandResult(true, "Sucesso", todo);
        }
    }
}