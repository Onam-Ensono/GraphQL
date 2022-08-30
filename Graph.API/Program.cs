using AppAny.HotChocolate.FluentValidation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Graph.API.Data;
using Graph.API.Mutations;
using Graph.API.Queries;
using Graph.API.Schemas;
using Graph.API.Services;
using Graph.API.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    // Fluent validation setup
    .AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssembly(typeof(CustomerValidator).Assembly)
    // Application services non specific to GraphQL to handle external API calls
    .AddTransient<IOrdersService, OrdersService>()
    // Entity framework injection
    .AddPooledDbContextFactory<FooDbContext>(opt => opt.UseInMemoryDatabase("Testing"))
    // GraphQL setup
    .AddGraphQLServer()
    // Query
    .AddQueryType<Query>()
    .AddTypeExtension<Query>()
    .AddType<CustomerType>()
    // Mutations
    .AddMutationConventions(applyToAllMutations: true)
    .AddMutationType<Mutation>()
    // Validation
    .AddFluentValidation()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    DataGenerator.Init(scope.ServiceProvider);
}

app.MapGraphQL();
app.Run();