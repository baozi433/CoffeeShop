using CoffeeShop.Models;
using CoffeeShop.Web.Services.Contracts;
using System.Net.Http.Json;

namespace CoffeeShop.Web.Services
{
    public class CoffeeService : ICoffeeService
    {
        private readonly HttpClient _httpClient;

        public CoffeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Coffee> GetCoffee()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/coffee/brew-coffee");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Coffee>();
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
