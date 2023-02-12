using CoffeeShop.Models;
using CoffeeShop.Web.Services.Contracts;
using System.Net.Http.Json;

namespace CoffeeShop.Web.Services
{
    public class CoffeeService : ICoffeeService
    {
        private readonly HttpClient _httpClient;
        private readonly IWeatherService _weatherService;

        public CoffeeService(HttpClient httpClient, IWeatherService weatherService)
        {
            _httpClient = httpClient;
            _weatherService = weatherService;
        }

        public async Task<Coffee> GetCoffee(double lat, double lon)
        {
            try
            {
                var weather = await _weatherService.GetWeather(lat, lon);
                var response = await _httpClient.GetAsync("api/coffee/brew-coffee");
                if (response.IsSuccessStatusCode)
                {
                    var coffee = await response.Content.ReadFromJsonAsync<Coffee>();
                    if (weather.Temperature <= 30.0)
                        return coffee;
                    else
                    {
                        coffee.Message = "Your refreshing iced coffee is ready";
                        return coffee;
                    }                  
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception e)
            {
                return new Coffee { Message = e.Message, Prepared = DateTime.MaxValue };
            }
        }
    }
}
