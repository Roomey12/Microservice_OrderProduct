using ProductMicroservice.EF;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationContext _context;
        ProductRepository _productRepository;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IRepository<Product> Products
        {
            get
            {
                if(_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
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
