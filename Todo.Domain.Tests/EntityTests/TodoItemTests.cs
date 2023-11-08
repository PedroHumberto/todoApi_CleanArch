using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _todo = new TodoItem("Titulo do Todo", DateTime.Now, "Pedro Cardoso");

        [TestMethod]
        public void When_crated_new_todo_done_need_to_be_false()
        {
            Assert.AreEqual(_todo.Done, false);
        }
        
    }
}