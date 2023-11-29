using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Context;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;
        private readonly IMemoryCache _memoryCache;


        public TodoRepository(TodoContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public void Create(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }
        public IEnumerable<TodoItem> GetAll(string user)
        {

            var key = $"user-{user}";

            return _memoryCache.GetOrCreate(key, entry=> {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                var todoList = _context.Todos.AsNoTracking().Where(TodoQueries.GetAll(user)).OrderBy(x => x.Date);

                return todoList;
            });
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _context.Todos.AsNoTracking().Where(TodoQueries.GetAllDone(user)).OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _context.Todos.AsNoTracking().Where(TodoQueries.GetAllUndone(user)).OrderBy(x => x.Date);
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _context.Todos.AsNoTracking().FirstOrDefault(u => u.Id == id && u.User == user);
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Todos.AsNoTracking().Where(predicate: TodoQueries.GetByPeriod(user, date, done)).OrderBy(x => x.Date);
        }

        public void Update(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}