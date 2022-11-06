namespace Domain.Dtos;
using Domain.Entites;
public class GetCustomerPurchacesDto
{
    public int Id { get; set; }
    public int InstallmentId { get; set; }
    public string? InstallmentName { get; set; }
    public int CustomersId { get; set; }
    public string? CustomersName { get; set; }
}
