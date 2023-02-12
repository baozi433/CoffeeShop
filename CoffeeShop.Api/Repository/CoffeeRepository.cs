using CoffeeShop.Api.Repository.Contract;
using CoffeeShop.Models;

namespace CoffeeShop.Api.Repository
{
    public class CoffeeRepository : ICoffeeRepository
    {
        public Task<Coffee> GetCoffee()
        {
            var coffee = new Coffee { Message = "Your piping hot coffee is ready", Prepared = DateTime.Now };
            return Task.FromResult(coffee);
        }
    }
}
