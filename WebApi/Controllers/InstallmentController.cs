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
    public async Task<Response<List<GetInstallmentDto>>> GetInstallment()
    {
        return await _installmentService.GetInstallment();
    }
    [HttpPost]
    public async Task<Response<string>> AddInstallment(AddInstallmentDto chalange)
    {
        return await _installmentService.AddInstallment(chalange);
    }
    [HttpPut]
    public async Task<Response<AddInstallmentDto>> UpdateInstallment(AddInstallmentDto chalange)
    {
        return await _installmentService.UpdateInstallment(chalange);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteInstallment(int id)
    {
        return await _installmentService.DaleteInstallment(id);
    }
}
