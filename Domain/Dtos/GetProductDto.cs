namespace Domain.Dtos;
using Domain.Entites;
public class GetProductDto
{

    public int Id { get; set; }
    public string? Name { get; set; }
    public int Price { get; set; }
    public List<Installment>? Installments { get; set; }
}
