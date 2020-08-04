using OrderMicroservice.Interfaces;
using OrderMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.Service
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database;

        public OrderService(IUnitOfWork database)
        {
            Database = database;
        }

        public void Create(Order order)
        {
            Database.Orders.Create(order);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Orders.Delete(id);
            Database.Save();
        }

        public IEnumerable<Order> GetAll()
        {
            return Database.Orders.GetAll();
        }

        public Order GetById(int id)
        {
            return Database.Orders.Get(id);
        }

        public void Update(Order order)
        {
            Database.Orders.Update(order);
            Database.Save();
        }
    }
}
