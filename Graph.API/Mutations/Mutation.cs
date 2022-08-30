using AppAny.HotChocolate.FluentValidation;
using Graph.API.Data;
using Graph.API.Models;
using Graph.API.Schemas;

namespace Graph.API.Mutations;

public class Mutation
{
    [UseDbContext(typeof(FooDbContext))]
    public bool AddCustomer(
        [UseFluentValidation] AddCustomerInput input,
        [ScopedService] FooDbContext context)
    {
        context.Add(new Customer()
        {
            Forename = input.Forename,
            LastName = input.Surname,
            CustomerId = Guid.NewGuid().ToString()
        });

        context.SaveChanges();
        return true;
    }
}