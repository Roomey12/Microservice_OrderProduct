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
    public class OrderItemRepository : IRepository<OrderItem>
    {
        private ApplicationContext _context;

        public OrderItemRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(OrderItem item)
        {
            _context.OrderItems.Add(item);
        }

        public void Delete(int id)
        {
            var order = _context.OrderItems.Find(id);
            if (order != null)
            {
                _context.OrderItems.Remove(order);
            }
        }

        public IEnumerable<OrderItem> Find(Func<OrderItem, bool> predicate)
        {
            return _context.OrderItems.Where(predicate).ToList();
        }

        public OrderItem Get(int id)
        {
            return _context.OrderItems.Find(id);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _context.OrderItems.ToList();
        }

        public void Update(OrderItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
