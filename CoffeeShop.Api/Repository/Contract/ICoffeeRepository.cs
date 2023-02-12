using CoffeeShop.Models;

namespace CoffeeShop.Api.Repository.Contract
{
    public interface ICoffeeRepository
    {
        Task<Coffee> GetCoffee();
    }
}
