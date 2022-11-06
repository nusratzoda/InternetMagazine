namespace Domain.Dtos;
using Domain.Entites;
public class GetInstallmentDto
{
    public int Id { get; set; }
    public int EndInstallement { get; set; }
    public int Percentage { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public List<CustomerPurchaces>? CustomerPurchaces { get; set; }
}
