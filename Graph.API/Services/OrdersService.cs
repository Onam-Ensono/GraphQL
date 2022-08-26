using Graph.API.Models;

namespace Graph.API.Services;


public interface IOrdersService
{
    ICollection<Order> GetOrdersByCustomerId(string customerId);
}


public class OrdersService : IOrdersService
{
    public ICollection<Order> GetOrdersByCustomerId(string customerId)
    {
        var orders = new List<Order>
        {
            new() { OrderId = $"{customerId}-99", CustomerId = "1" },
            new() { OrderId = $"{customerId}-98", CustomerId = "2" }
        };
        return orders
            .Where(x => x.CustomerId == customerId)
            .ToList();
    }
}