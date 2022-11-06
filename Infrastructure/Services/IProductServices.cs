using Domain.Dtos;
using Domain.Wrapper;
namespace Infrastructure.Services;

public interface IProductServices
{
    Task<Response<AddProductDto>> AddProduct(AddProductDto model);
    Task<Response<string>> DaleteProduct(int id);
    Task<Response<List<GetProductDto>>> GetProduct();
    Task<Response<AddProductDto>> UpdateProduct(AddProductDto model);
}
