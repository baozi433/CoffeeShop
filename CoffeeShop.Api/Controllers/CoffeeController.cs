using CoffeeShop.Api.Repository.Contract;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using System.Net;
using System.Net.NetworkInformation;

namespace CoffeeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly IOrderRepository _orderRepository;

        public const int apiCallConditionNumber = 5;
        public DateTime apiCallConditionDate = new DateTime(2023, 4, 11);

        public int orderNumbers;

        public CoffeeController(ICoffeeRepository coffeeRepository, IOrderRepository orderRepository)
        {
            _coffeeRepository = coffeeRepository;
            _orderRepository = orderRepository;

            orderNumbers = _orderRepository.GetOrderNumbers().Result;
        }

        [HttpGet("brew-coffee")]
        public async Task<ActionResult<Coffee>> GetCoffee([FromQuery] double temperature)
        {
            try
            {
                var order = new Order { OrderTime = DateTime.Now };
                await _orderRepository.AddOrder(order);

                orderNumbers++;

                var coffee = await _coffeeRepository.GetCoffee();
                
                if (coffee == null)
                {
                    return NotFound();
                }
                else if (orderNumbers % apiCallConditionNumber == 0)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "");
                }

                else if (order.OrderTime.Month == apiCallConditionDate.Month && order.OrderTime.Day == apiCallConditionDate.Day)
                {
                    return StatusCode(StatusCodes.Status418ImATeapot, "");
                }
                else if (temperature >= 30.0)
                {
                    coffee.Message = "Your refreshing iced coffee is ready";
                    return Ok(coffee);
                }
                else
                {
                    return Ok(coffee);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
