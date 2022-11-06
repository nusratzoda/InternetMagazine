using Domain.Dtos;
using Domain.Entites;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace InternetMagazin.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductServices _productService;



    public ProductController(IProductServices productService)
    {
        _productService = productService;
    }
    [HttpGet]
    public async Task<Response<List<GetProductDto>>> GetProduct()
    {
        return await _productService.GetProduct();
    }

    [HttpPost]
    public async Task<Response<AddProductDto>> AddProduct(AddProductDto chalange)
    {
        return await _productService.AddProduct(chalange);
    }
    [HttpPut]
    public async Task<Response<AddProductDto>> UpdateProduct(AddProductDto chalange)
    {
        return await _productService.UpdateProduct(chalange);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteProduct(int id)
    {
        return await _productService.DaleteProduct(id);
    }
}
