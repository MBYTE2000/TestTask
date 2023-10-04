using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.EF
{
    public class OrderService : IOrderService
    {
        public readonly ApplicationDbContext dbContext;
        public OrderService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<Order> GetOrder()
        {
            var order = dbContext.Orders.OrderByDescending(o => o.Price).FirstOrDefault();
            return order;
        }

        public async Task<List<Order>> GetOrders()
        {
            var orders = dbContext.Orders.Where(o => o.Quantity > 10);
            return orders.ToList();
        }
    }
}
