
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo da Tarefa Que Vai Ser Adicionada", "Pedro Cardoso", DateTime.UtcNow);

        [TestMethod]
        public void When_command_is_invalid()
        {
            
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.IsValid, false);
            
        }
        
        [TestMethod]
        public void When_command_is_valid()
        {
            
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.IsValid, true);
        }
    }
}