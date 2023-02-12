using CoffeeShop.Models;

namespace CoffeeShop.Web.Services.Contracts
{
    public interface ICoffeeService
    {
        Task<Coffee> GetCoffee();
    }
}
