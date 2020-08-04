using Microsoft.EntityFrameworkCore;
using OrderMicroservice.EF;
using OrderMicroservice.Interfaces;
using OrderMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Order item)
        {
            _context.Orders.Add(item);
        }

        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if(order != null)
            {
                _context.Orders.Remove(order);
            }
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return _context.Orders.Where(predicate).ToList();
        }

        public Order Get(int id)
        {
            return _context.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public void Update(Order item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
