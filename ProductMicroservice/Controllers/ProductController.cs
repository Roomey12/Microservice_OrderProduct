using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.Delete(id);
            return Ok("success");
        }

        [HttpPut]
        public IActionResult PutProduct([FromBody]Product product)
        {
            _productService.Update(product);
            return Ok("put success");
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody]Product product)
        {
            _productService.Create(product);
            return Ok("success");
        }
    }
}
