namespace Domain.Dtos;
using Domain.Entites;
public class GetCustomerPurchacesDto
{
    public int Id { get; set; }
    public int InstallmentId { get; set; }
    public virtual Installment? Installment { get; set; }
    public int CustomersId { get; set; }
    public virtual Customers? Customers { get; set; }
}
