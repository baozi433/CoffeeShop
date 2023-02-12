
using CoffeeShop.Models;

namespace CoffeeShop.Web.Services.Contracts
{
    public interface IWeatherService
    {
        Task<Weather> GetWeather(double latitude, double longitude);
    }
}
