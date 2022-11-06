using Domain.Dtos;
using Domain.Wrapper;
namespace Infrastructure.Services;

public interface ICustomerPurchacesServices
{
    Task<Response<string>> AddCustomerPurchaces(AddCustomerPurchacesDto model);
    Task<Response<string>> DaleteInstallment(int id);
    Task<Response<AddCustomerPurchacesDto>> UpdateCustomerPurchaces(AddCustomerPurchacesDto model);
}
