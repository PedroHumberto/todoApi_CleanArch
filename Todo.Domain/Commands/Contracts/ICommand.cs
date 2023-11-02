using System;
using Flunt.Notifications;

namespace Todo.Domain.Commands.Contracts
{
    public interface ICommand
    {
        void Validate();
    }
}