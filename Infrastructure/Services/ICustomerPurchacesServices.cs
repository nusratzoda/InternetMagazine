using Domain.Dtos;
using Domain.Wrapper;
namespace Infrastructure.Services;

public interface ICustomerPurchacesServices
{
    Task<Response<List<GetCustomerPurchacesDto>>> GetCustomerPurchaces();
    Task<Response<AddCustomerPurchacesDto>> AddCustomerPurchaces(AddCustomerPurchacesDto model);
    Task<Response<string>> DaleteCustomerPurchaces(int id);
    Task<Response<AddCustomerPurchacesDto>> UpdateCustomerPurchaces(AddCustomerPurchacesDto model);
}
