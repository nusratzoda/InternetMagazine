namespace Infrastructure.Services;
using Infrastructure.Services;
using Domain.Dtos;
using Domain.Wrapper;
public interface IInstallmentServices
{
    Task<Response<List<GetInstallmentDto>>> GetInstallment();
    Task<Response<AddInstallmentDto>> UpdateInstallment(AddInstallmentDto model);
    Task<Response<AddInstallmentDto>> AddInstallment(AddInstallmentDto model);
    Task<Response<string>> DaleteInstallment(int id);
}
