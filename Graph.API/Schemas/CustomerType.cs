using Graph.API.Models;
using Graph.API.Resolvers;

namespace Graph.API.Schemas;

public class CustomerType : ObjectType<Customer>
{
    protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
    {
        base.Configure(descriptor);

        descriptor
            .Field(x => x.Orders)
            .ResolveWith<OrdersResolver>(r => r.Resolve(default, default));
    }
}