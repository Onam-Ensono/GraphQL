using Graph.API.Models;
using Graph.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Graph.API.Resolvers;

public class OrdersResolver
{
    public ICollection<Order> Resolve([Parent] Customer customer, [FromServices] IOrdersService ordersService)
    {
        var orders = ordersService.GetOrdersByCustomerId(customer.CustomerId);
        return orders;
    }
}