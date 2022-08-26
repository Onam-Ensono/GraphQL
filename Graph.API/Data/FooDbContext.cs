using Graph.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Graph.API.Data;

public class FooDbContext : DbContext
{
    private readonly DbContextOptions<FooDbContext> _options;

    public FooDbContext(DbContextOptions<FooDbContext> options) : base(options)
    {
        _options = options;
    }
    
    public DbSet<Customer> Customers { get; set; }
}