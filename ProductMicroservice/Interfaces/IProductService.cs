using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Delete(int id);
        void Update(Product product);
        void Create(Product product);
    }
}
