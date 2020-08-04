using OrderMicroservice.EF;
using OrderMicroservice.Interfaces;
using OrderMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationContext _context;
        OrderRepository _orderRepository;
        OrderItemRepository _orderItemRepository;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_context);
                }
                return _orderRepository;
            }
        }

        public IRepository<OrderItem> OrderItems
        {
            get
            {
                if (_orderItemRepository == null)
                {
                    _orderItemRepository = new OrderItemRepository(_context);
                }
                return _orderItemRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
