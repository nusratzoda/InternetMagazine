namespace Domain.Entites;

public class Customers
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public virtual List<CustomerPurchaces>? CustomerPurchaces { get; set; }
}
