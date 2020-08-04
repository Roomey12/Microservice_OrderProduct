using OrderMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Delete(int id);
        void Update(Order order);
        void Create(Order order);
    }
}
