using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Domain.BackOfficeContext{
    public class Customer{
        public IReadOnlyCollection<Product> Products {get;set;}
        public Name Name{get;set;}
    }
}