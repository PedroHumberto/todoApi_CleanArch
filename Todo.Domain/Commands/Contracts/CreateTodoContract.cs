using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Validations;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands.Contracts
{
    public class CreateTodoContract : Contract<CreateTodoCommand>
    {
        public CreateTodoContract(CreateTodoCommand todoCommand)
        {
            Requires()
                .IsLowerThan(todoCommand.Title, 3, "Title", "A tarefa deve conter mais de 3 caracteres")
                .IsLowerThan(todoCommand.User, 6, "User", "Invalid User");
        }
    }
}