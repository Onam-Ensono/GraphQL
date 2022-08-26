namespace Graph.API.Models;

public class Customer
{
    public Customer()
    {
        Orders = new List<Order>();
    }
    
    public string CustomerId { get; set; }
    
    public string Forename { get; set; }
    
    public string LastName { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}