using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using System.Collections.Generic;
using System;

namespace BaltaStore.Tests{
    public class FakeCustomerRepository:ICustomerRepository{
        public bool CheckDocument(string document){
            return false;
        }

        public bool CheckEmail(string email){
            return false;
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customer customer){
            throw new System.NotImplementedException();
        }

        public IEnumerable<ListCustomerQueryResult> Get(){
            throw new System.NotImplementedException();
        }

        public GetCustomerQueryResult Get(Guid id){
            throw new System.NotImplementedException();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id){
            throw new System.NotImplementedException();
        }
    }
}