using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        void Save();
        Task SaveAsync();
    }
}
