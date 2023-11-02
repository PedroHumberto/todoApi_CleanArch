using System;
using Flunt.Notifications;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand : Notifiable<Notification>, ICommand
    {
        public CreateTodoCommand()
        {
        }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
            AddNotifications(new CreateTodoContract(this));
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}