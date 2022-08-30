using Graph.API.Events;
using Graph.API.Models;

namespace Graph.API.Subscriptions;

public class Subscription
{
    [Subscribe]
    [Topic(nameof(CustomerAdded))]
    public Customer CustomerAdded([EventMessage] CustomerAdded e)
    {
        return new Customer
        {
            Forename = e.Forename,
            LastName = e.Surname,
            CustomerId = e.Id
        };
    }
}