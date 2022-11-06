namespace Domain.Entites;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Price { get; set; }
    public virtual List<Installment>? Installments { get; set; }
}
