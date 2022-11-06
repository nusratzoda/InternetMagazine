namespace Infrastructure.Context;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Installment> Installments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CustomerPurchaces> CustomerPurchaces { get; set; }
}

