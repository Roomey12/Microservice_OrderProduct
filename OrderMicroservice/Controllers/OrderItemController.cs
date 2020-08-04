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
    public class OrderItemController : ControllerBase
    {
        IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public IActionResult GetAllOrderItems()
        {
            var orders = _orderItemService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderItem(int id)
        {
            var order = _orderItemService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderItem(int id)
        {
            _orderItemService.Delete(id);
            return Ok("delete success");
        }

        [HttpPut]
        public IActionResult PutOrderItem([FromBody]OrderItem orderItem)
        {
            _orderItemService.Update(orderItem);
            return Ok("put success");
        }

        [HttpPost]
        public IActionResult PostOrderItem([FromBody]OrderItem orderItem)
        {
            _orderItemService.Create(orderItem);
            return Ok("success");
        }
    }
}
