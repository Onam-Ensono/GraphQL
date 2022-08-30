using AppAny.HotChocolate.FluentValidation;
using Graph.API.Data;
using Graph.API.Events;
using Graph.API.Models;
using Graph.API.Schemas;
using HotChocolate.Subscriptions;

namespace Graph.API.Mutations;

public class Mutation
{
    [UseDbContext(typeof(FooDbContext))]
    public bool AddCustomer(
        [UseFluentValidation] AddCustomerInput input,
        [ScopedService] FooDbContext context,
        [Service] ITopicEventSender sender)
    {
        var customer = new Customer()
        {
            Forename = input.Forename,
            LastName = input.Surname,
            CustomerId = Guid.NewGuid().ToString()
        };
        context.Add(customer);

        context.SaveChanges();
        sender.SendAsync(nameof(CustomerAdded), customer).GetAwaiter().GetResult();
        return true;
    }
}