using CoffeeShop.Models;
using CoffeeShop.Web.Services.Contracts;
using System.Net.Http.Json;

namespace CoffeeShop.Web.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Weather> GetWeather(double latitude, double longitude)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/weather/{latitude}/{longitude}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Weather>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
