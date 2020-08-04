using OrderMicroservice.Interfaces;
using OrderMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.Service
{
    public class OrderItemService : IOrderItemService
    {
        IUnitOfWork Database;

        public OrderItemService(IUnitOfWork database)
        {
            Database = database;
        }

        public void Create(OrderItem orderItem)
        {
            Database.OrderItems.Create(orderItem);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.OrderItems.Delete(id);
            Database.Save();
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return Database.OrderItems.GetAll();
        }

        public OrderItem GetById(int id)
        {
            return Database.OrderItems.Get(id);
        }

        public void Update(OrderItem orderItem)
        {
            Database.OrderItems.Update(orderItem);
            Database.Save();
        }
    }
}
