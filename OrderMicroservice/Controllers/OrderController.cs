using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Interfaces;
using OrderMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.Delete(id);
            return Ok("delete success");
        }

        [HttpPut]
        public IActionResult PutOrder([FromBody]Order order)
        {
            _orderService.Update(order);
            return Ok("put success");
        }

        [HttpPost]
        public IActionResult PostOrder([FromBody]Order order)
        {
            _orderService.Create(order);
            return Ok("success");
        }
    }
}
