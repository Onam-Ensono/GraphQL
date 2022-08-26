using Graph.API.Data;
using Graph.API.Models;

namespace Graph.API.Queries;

public class Query
{
    [UseDbContext(typeof(FooDbContext))]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Customer> Customers([ScopedService] FooDbContext context)
    {
        var customers = context.Customers;
        return customers.AsQueryable();
    }
    
    [UseDbContext(typeof(FooDbContext))]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Customer> Customers([ScopedService] FooDbContext context, string customerId)
    {
        var customers = context.Customers.Where(x => x.CustomerId == customerId);
        return customers;
    }
}