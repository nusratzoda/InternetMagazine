using Infrastructura.Cantext;
using Infrastructura.InfrastructuraMapper;
using Infrastructura.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IInstallmentServices, InstallmentServices>();
builder.Services.AddScoped<IproductServices, ProductServices>();
builder.Services.AddScoped<ICustomerPurchacesServices, CustomerPurchacesServices>();
builder.Services.AddAutoMapper(typeof(ServicesProfile));
//register database
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();