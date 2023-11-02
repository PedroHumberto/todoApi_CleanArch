
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable<Notification>, ICommand
    {
        public UpdateTodoCommand()
        {
        }

        public UpdateTodoCommand(Guid id, string newTitle, string user)
        {
            Id = id;
            NewTitle = newTitle;
            User = user;
        }

        public Guid Id { get; set; }
        public string NewTitle { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<UpdateTodoCommand>()
            .Requires()
            .IsLowerThan(NewTitle, 3, "Title", "A tarefa deve conter mais de 3 caracteres")
            .IsLowerThan(User, 6, "User", "Invalid User"));
        }
    }
}