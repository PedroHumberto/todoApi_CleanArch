
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        [TestMethod]
        public void When_command_is_invalid()
        {
            var command = new CreateTodoCommand("", "", DateTime.Now);
            command.Validate();
            Assert.AreEqual(command.IsValid, false);
            
        }
        
        [TestMethod]
        public void When_command_is_valid()
        {
            var command = new CreateTodoCommand("Titulo da Tarefa Que Vai Ser Adicionada", "Pedro Cardoso", DateTime.UtcNow);
            command.Validate();
            Assert.AreEqual(command.IsValid, true);
        }
    }
}