using Domain.Dtos;
using Domain.Entites;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace InternetMagazin.Controllers;
[ApiController]
[Route("[controller]")]
public class InstallmentController : ControllerBase
{
    private readonly IInstallmentServices _installmentService;
    public InstallmentController(IInstallmentServices installService)
    {
        _installmentService = installService;
    }
    [HttpGet]
    public async Task<Response<List<GetInstallment>>> GetInstallment()
    {
        return await _installmentService.GetInstallment();
    }
    [HttpPost]
    public async Task<Response<AddInstallmentDto>> AddChalange(AddInstallmentDto chalange)
    {
        return await _customerService.AddInstallment(chalange);
    }
    [HttpPut]
    public async Task<Response<AddInstallment>> UpdateCustomer(AddCustomerDto chalange)
    {
        return await _customerService.UpdateCustomer(chalange);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteCustomer(int id)
    {
        return await _customerService.DaleteCustomer(id);
    }
}
