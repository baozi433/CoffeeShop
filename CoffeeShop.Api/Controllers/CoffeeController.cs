﻿using CoffeeShop.Api.Repository.Contract;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        public CoffeeController(ICoffeeRepository coffeeRepository, IOrderRepository orderRepository)
        {
            _coffeeRepository = coffeeRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet("brew-coffee")]
        public async Task<ActionResult<Coffee>> GetCoffee()
        {
            try
            {
                var order = new Order { OrderTime = DateTime.Now };
                await _orderRepository.AddOrder(order);

                var coffee = await _coffeeRepository.GetCoffee();
                var orderNumbers = await _orderRepository.GetOrderNumbers();

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
