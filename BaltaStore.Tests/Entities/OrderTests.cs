using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class OrderTests
    {
        private Customer _customer;
        private Order _order;
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;

        public OrderTests()
        {
            var name = new Name("Andre", "Baltieri");
            var document  = new Document("46718115533");
            var email = new Email("hello@balta.io");
            _customer = new Customer(name, document, email, "551999876542");
            _order = new Order(_customer);
            _mouse = new Product("Mouse gamer", "Mouse gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Teclado gamer", "Teclado gamer", "teclado.jpg", 99M, 10);
            _chair = new Product("Cadeira gamer", "Cadeira gamer", "cadeira.jpg", 99M, 10);
            _monitor = new Product("Monitor gamer", "Monitor gamer", "monitor.jpg", 99M, 10);

        }

        //Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid(){
            //Assert.Fail(true, _order.IsValid());
        }

        //Ao criar o pedido, o status deve ser Created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated(){
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        //Ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems(){
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        //Ao adicionar um novo item, deve substrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem(){
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        //Ao configurar pedido, deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced(){
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        //Ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid(){
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        //Dados mais 10 produtos, deve haver duas entregas
        [TestMethod]
        public void ShouldTwoShippingsWhenPurchasedTenProducts(){
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        //Ao cancelar o pedido, status deve ser Canceled
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled(){
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        //Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled(){
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.Ship();
            _order.Cancel();
            foreach (var x in _order.Deliveries){
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
            
        }

        public void CreateCustomer(){
            //Verifica se o CPF ja existe
            //verifica se o e-mai ja existe
            //criar os VOs
            //criar a entidade
            //validar as entidades e VO
            //inserir o cliente no banco
            //Envia convite do Slack
            //Enviar um e-mail de boas vindas

            
        }


    }
}
