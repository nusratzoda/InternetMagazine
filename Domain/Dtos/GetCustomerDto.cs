namespace Domain.Dtos;
using Domain.Entites;
public class GetCustomerDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public List<CustomerPurchaces>? CustomerPurchaces { get; set; }
}
