using Microsoft.EntityFrameworkCore;
using ProductMicroservice.EF;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if(product != null)
            {
                _context.Products.Remove(product);
            }
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return _context.Products.Where(predicate).ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id); 
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(Product item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
