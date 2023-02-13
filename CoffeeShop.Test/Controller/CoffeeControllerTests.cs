using CoffeeShop.Api.Controllers;
using CoffeeShop.Api.Repository.Contract;
using CoffeeShop.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Test.Controller
{
    public class CoffeeControllerTests
    {
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly IOrderRepository _orderRepository;

        public CoffeeControllerTests()
        {
            _coffeeRepository = A.Fake<ICoffeeRepository>();
            _orderRepository = A.Fake<IOrderRepository>();
        }

        [Fact]
        public void CoffeeController_GetCoffee_ReturnOK()
        {
            //Arrange
            var coffee = A.Fake<Coffee>();
            A.CallTo(() => _coffeeRepository.GetCoffee()).Returns(coffee);
            var controller = new CoffeeController(_coffeeRepository, _orderRepository);
            
            //Act
            var actionResult = controller.GetCoffee().Result;

            //Assert
            var result = actionResult.Result as OkObjectResult;        
        }

        [Fact]
        public void CoffeeController_GetCoffee_ReturnNotFound()
        {
            //Arrange
            var coffee = A.Fake<Coffee>();

            A.CallTo(() => _coffeeRepository.GetCoffee()).Returns(coffee);
            var controller = new CoffeeController(_coffeeRepository, _orderRepository);

            //Act
            var actionResult = controller.GetCoffee().Result;

            //Assert
            var result = actionResult.Result as NotFoundResult;
        }



    }
}
