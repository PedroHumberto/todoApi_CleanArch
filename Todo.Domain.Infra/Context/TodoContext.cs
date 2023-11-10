using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> opts) : base(opts)
        {

        }

        public DbSet<TodoItem> Todos {get; set;}
    }
}