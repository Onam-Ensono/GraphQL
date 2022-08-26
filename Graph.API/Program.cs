using Graph.API.Data;
using Graph.API.Queries;
using Graph.API.Schemas;
using Graph.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    // Application services non specific to GraphQL to handle external API calls
    .AddTransient<IOrdersService, OrdersService>()
    // Entity framework injection
    .AddPooledDbContextFactory<FooDbContext>(opt => opt.UseInMemoryDatabase("Testing"))
    // GraphQL setup
    .AddGraphQLServer()
    .AddQueryType<Query>()
    //.AddQueryType(q => q.Name("Query"))
    .AddTypeExtension<Query>()
    //.AddTypeExtension<BookExtensions>()
    .AddType<CustomerType>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    DataGenerator.Init(scope.ServiceProvider);
}

app.MapGraphQL();
app.Run();