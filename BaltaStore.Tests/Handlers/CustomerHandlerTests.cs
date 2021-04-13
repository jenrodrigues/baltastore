using BaltaStore.Domain.StoreContext.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests{
    [TestClass]
    public class CustomerHandlerTests{
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid(){
            var command = new CreateCustomerCommand();
            command.FirstName= "Andre";
            command.LastName = "Baltieri";
            command.Document = "28659170377";
            command.Email = "andrebaltieri@gmail.com";
            command.Phone = "11999999997";

            Assert.AreEqual(true, command.Valid);

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.Valid);
        }
    }
}