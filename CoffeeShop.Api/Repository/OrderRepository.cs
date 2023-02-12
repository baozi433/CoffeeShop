using CoffeeShop.Api.Data;
using CoffeeShop.Api.Repository.Contract;
using CoffeeShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CoffeeShop.Api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        //public static List<Order> orders = new List<Order>();

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddOrder(Order order)
        {
            _dataContext.Orders.Add(order);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<int> GetOrderNumbers()
        {
            var orders =  await _dataContext.Orders.ToListAsync();
            return orders.Count;
        }

        public async Task<List<Order>> GetOrders()
        {
            var orders = await _dataContext.Orders.ToListAsync();
            return orders;
        }
    }
}
