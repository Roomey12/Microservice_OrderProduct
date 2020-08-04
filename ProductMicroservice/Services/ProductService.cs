using ProductMicroservice.Interfaces;
using ProductMicroservice.Models;
using ProductMicroservice.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork Database;

        public ProductService(IUnitOfWork database)
        {
            Database = database;
        }

        public void Create(Product product)
        {
            Database.Products.Create(product);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Products.Delete(id);
            Database.Save();
        }

        public IEnumerable<Product> GetAll()
        {
            return Database.Products.GetAll();
        }

        public Product GetById(int id)
        {
            return Database.Products.Get(id);
        }

        public void Update(Product product)
        {
            Database.Products.Update(product);
            Database.Save();
        }
    }
}
