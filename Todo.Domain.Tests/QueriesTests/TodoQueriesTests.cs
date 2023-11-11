using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;

        public TodoQueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", DateTime.Now, "usuario A"));
            _items.Add(new TodoItem("Tarefa 2", DateTime.Now, "usuario A"));
            _items.Add(new TodoItem("Tarefa 3", DateTime.Now, "usuario A"));
            _items.Add(new TodoItem("Tarefa do Pedro", DateTime.Now, "Pedro"));
            _items.Add(new TodoItem("Tarefa 2 do Pedro", DateTime.Now, "Pedro"));
        }
        [TestMethod]
        public void When_user_Get_Tasks_Only_Return_this_user_Todo_Items()
        {
            //GET ALL TASKS FROM PEDRO ONLY
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Pedro"));

            Assert.AreEqual(2, result.Count());
        }
    }
}