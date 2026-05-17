using Microsoft.AspNetCore.Mvc;
using E_Commerce_API.src.Service;
using E_Commerce_API.src.Models;
using E_Commerce_API.src.DTO;

namespace E_Commerce_API.src.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OrderController : ControllerBase
    {
        public readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDTO orderDto)
        {
            var createdOrder = await _orderService.CreatedOrder(orderDto.ProductsId, orderDto.UserId);
            return Created("", new OrderResponseDTO
            {
                OrderId = createdOrder.Id,
                UserId = createdOrder.UserId,
                Products = createdOrder.Products.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList()
            });
        }
    }
}
