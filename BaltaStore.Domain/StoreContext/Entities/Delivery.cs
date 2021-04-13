using System;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities{
    public class Delivery: Entity{
        public Delivery(DateTime estimatedDeliveryDate){
            CreateDate = DateTime.Now;
            DeliveryDateEstimate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        public DateTime CreateDate{get;private set;}
        public DateTime DeliveryDateEstimate{get;private set;}
        public EDeliveryStatus Status{get;private set;}

        public void Ship(){
            //Se a data estimade de entrega for no passado, nao entregar
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel(){
            //Se o status ja estiver entregue, nao pode cancelar
            Status = EDeliveryStatus.Canceled;
        }
    }
}