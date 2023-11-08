using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Domain.Entities
{
    public class TodoItem : Entity
    {
        public TodoItem(string title, DateTime date, string user)
        {
            Title = title;
            Done = false;
            Date = date;
            FinishedAt = null;
            User = user;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public string User { get; private set; }

        public void MarkAsDone()
        {
            FinishedAt = DateTime.UtcNow;
            Done = true;
        }
        public void MarkAsUndone()
        {
            FinishedAt = null;
            Done = false;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
    }
}