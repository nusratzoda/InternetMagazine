using Domain.Dtos;
using Domain.Entites;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace InternetMagazin.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomersServices _customerService;
    public CustomerController(ICustomersServices customerService)
    {
        _customerService = customerService;
    }
    [HttpGet]
    public async Task<Response<List<GetCustomerDto>>> GetCustomer()
    {
        return await _customerService.GetCustomer();
    }

    [HttpPost]
    public async Task<Response<AddCustomerDto>> AddChalange(AddCustomerDto chalange)
    {
        return await _customerService.AddCustomer(chalange);
    }
    [HttpPut]
    public async Task<Response<AddCustomerDto>> UpdateCustomer(AddCustomerDto chalange)
    {
        return await _customerService.UpdateCustomer(chalange);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteCustomer(int id)
    {
        return await _customerService.DaleteCustomer(id);
    }
}
