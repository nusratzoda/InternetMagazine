using Domain.Dtos;
using Domain.Wrapper;
namespace Infrastructure.Services;

public interface ICustomersServices
{
    Task<Response<List<GetCustomerDto>>> GetCustomer();
    Task<Response<AddCustomerDto>> AddCustomer(AddCustomerDto model);
    Task<Response<string>> DaleteCustomer(int id);
    Task<Response<AddCustomerDto>> UpdateCustomer(AddCustomerDto model);
}
