using CoffeeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace CoffeeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public WeatherController(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        [HttpGet("{latitude}/{longitude}")]
        public async Task<ActionResult<Weather>> GetWeatherByGPS(double latitude, double longitude)
        {
            var apiKey = _config.GetSection("OpenweatherApiKey").Value;

            var url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric";
            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            dynamic weatherData = JsonConvert.DeserializeObject(json);
            double temperature = weatherData.main.temp;
            string description = weatherData.weather[0].description;
            string city = weatherData.name;
            string country = weatherData.sys.country;

            return Ok(new Weather {Temperature = temperature, Description = description, City = city, Country = country});
        }
    }
}
