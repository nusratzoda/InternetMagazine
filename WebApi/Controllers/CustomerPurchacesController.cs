using Domain.Dtos;
using Domain.Entites;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace InternetMagazin.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerPurchacesControler:ControllerBase
{
    private readonly ICustomerPurchacesServices _customerService;
    public CustomerPurchacesControler(ICustomerPurchacesServices customerService)
    {
        _customerService = customerService;
    }
    [HttpGet]
    public async Task<Response<List<GetCustomerPurchacesDto>>> GetCustomerPurchaces()
    {
        return await _customerService.GetCustomerPurchaces();
    }
    [HttpPost]
    public async Task<Response<AddCustomerPurchacesDto>> AddCustomerPurchaces(AddCustomerPurchacesDto chalange)
    {
        return await _customerService.AddCustomerPurchaces(chalange);
    }
    [HttpPut]
    public async Task<Response<AddCustomerPurchacesDto>> UpdateCustomerPurchaces(AddCustomerPurchacesDto chalange)
    {
        return await _customerService.UpdateCustomerPurchaces(chalange);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteCustomerPurchaces(int id)
    {
        return await _customerService.DaleteCustomerPurchaces(id);
    }
}
