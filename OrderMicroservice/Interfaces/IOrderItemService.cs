using OrderMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.Interfaces
{
    public interface IOrderItemService
    {
        IEnumerable<OrderItem> GetAll();
        OrderItem GetById(int id);
        void Delete(int id);
        void Update(OrderItem order);
        void Create(OrderItem order);
    }
}
