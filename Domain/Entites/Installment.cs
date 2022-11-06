namespace Domain.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Installment
{
    public int Id { get; set; }
    public int EndInstallement { get; set; }
    public int Percentage { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ChallangeId")]
    public virtual Product? Product { get; set; }
    public virtual List<CustomerPurchaces>? CustomerPurchaces { get; set; }
}
