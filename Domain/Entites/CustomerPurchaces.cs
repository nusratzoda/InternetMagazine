namespace Domain.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CustomerPurchaces
{
    public int Id { get; set; }
    public int InstallmentId { get; set; }
      [ForeignKey("InstallmentId")]
    public virtual Installment? Installment { get; set; }
    public int CustomersId { get; set; }
      [ForeignKey("CustomersId")]
    public virtual Customers? Customers { get; set; }
}
