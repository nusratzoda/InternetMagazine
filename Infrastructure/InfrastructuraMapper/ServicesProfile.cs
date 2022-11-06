namespace Infrastructure.InfrastructuraMapper;
using Domain.Dtos;
using Domain.Entites;
using AutoMapper;
public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        CreateMap<Installment, GetInstallmentDto>().ReverseMap();
        CreateMap<Customers, GetCustomerDto>().ReverseMap();
        CreateMap<Product, GetProductDto>().ReverseMap();
        CreateMap<CustomerPurchaces, GetCustomerPurchacesDto>().ReverseMap();
        CreateMap<Customers, AddCustomerDto>().ReverseMap();
        CreateMap<Installment, AddInstallmentDto>().ReverseMap();
        CreateMap<Product, AddProductDto>().ReverseMap();
        CreateMap<CustomerPurchaces, AddCustomerPurchacesDto>().ReverseMap();
    }
}
