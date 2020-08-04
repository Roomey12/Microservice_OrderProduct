using OrderMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        void Save();
        Task SaveAsync();
    }
}
