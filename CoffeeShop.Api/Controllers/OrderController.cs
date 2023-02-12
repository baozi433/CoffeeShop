using CoffeeShop.Api.Repository;
using CoffeeShop.Api.Repository.Contract;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("addorder")]
        public async Task<ActionResult<List<Order>>> AddOrder(Order order)
        {
            try
            {
                if(order == null)
                {
                    return BadRequest();
                }
                await _orderRepository.AddOrder(order);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("getordernumber")]
        public async Task<ActionResult<int>> GetOrderNumbers()
        {
            try
            {
                var number = await _orderRepository.GetOrderNumbers();
                return Ok(number);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
