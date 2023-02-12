using CoffeeShop.Models;

namespace CoffeeShop.Api.Repository.Contract
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
        Task<List<Order>> GetOrders();
        Task<int> GetOrderNumbers();
    }
}
