using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities{
    public class Order: Entity{
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
    public Order(Customer customer)
    {
        Customer = customer;
        CreateDate = DateTime.Now;
        Status = EOrderStatus.Created;
        _items = new List<OrderItem>();
        _deliveries = new List<Delivery>();

    }        
        public Customer Customer{get;private set;}
        public string Number{get;private set;}
        public DateTime CreateDate{get;private set;}
        public EOrderStatus Status{get;private set;}
        
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity){
            //Valida item
            if(quantity > product.QuantityOnHand){
                AddNotification("Order", $"Produto {product.Title} nao tem {quantity} em estoque.");
            }

            var item = new OrderItem(product, quantity);
            //AddItem(item);
        }

        public void AddDelivery(Delivery delivery){
            _deliveries.Add(delivery);
        }
        public void Place(){
            //gera o numero do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,8).ToUpper();

            if(_items.Count ==0){
                AddNotification("Order", "Esse pedido nao possui itens");
            }

        }
        
        //pagar pedido
        public void Pay(){
            Status = EOrderStatus.Paid;
        }

        //enviar pedido
        public void Ship(){
            //a cada 5 produtos e uma entrega
            var deliveries = new List<Delivery>();
            //deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;
            foreach(var item in _items){
                if(count ==5){
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            //envia todas as entregas
            deliveries.ForEach(x=> x.Ship());

            //adiciona as entregas ao pedido
            deliveries.ForEach(x=> _deliveries.Add(x));

        }

        //cancelar pedido
        public void Cancel(){
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x=>x.Cancel());
        }
    }
}