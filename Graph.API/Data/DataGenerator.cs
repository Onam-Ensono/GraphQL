using Graph.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Graph.API.Data;

public class DataGenerator
{
    public static void Init(IServiceProvider serviceProvider)
    {
        var options = serviceProvider.GetRequiredService<DbContextOptions<FooDbContext>>();
        
        using (var context = new FooDbContext(options))
        {
            context.Customers.AddRange(
                new Customer { CustomerId  = "1", Forename = "Thierry", LastName = "Henry" },
                new Customer { CustomerId  = "2", Forename = "Foo", LastName = "Bar" },
                new Customer { CustomerId  = "3", Forename = "Paul", LastName = "Phoenix" });

            context.SaveChanges();
        }
    }
}