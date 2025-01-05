using System.Threading.Tasks;
using WealthWise.API.Models;

namespace WealthWise.API.Data
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
    }
}
