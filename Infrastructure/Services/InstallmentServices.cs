using AutoMapper;
using Domain.Dtos;
using Domain.Entites;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services;
public class InstallmentServices : IInstallmentServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public InstallmentServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<GetInstallmentDto>>> GetInstallment()
    {

        var installment = await (from ins in _context.Installments
                                 join pro in _context.Products
                                 on ins.ProductId equals pro.Id
                                 select new GetInstallmentDto()
                                 {
                                     EndInstallement = ins.EndInstallement,
                                     Id = ins.Id,
                                     Percentage = ins.Percentage,
                                     ProductId = pro.Id,
                                     ProductName = pro.Name,
                                     CustomerPurchaces = (from cu in _context.CustomerPurchaces
                                                          where ins.Id == cu.CustomersId
                                                          select _mapper.Map<CustomerPurchaces>(cu)
                                                     ).ToList()

                                 }).ToListAsync();
        return new Response<List<GetInstallmentDto>>(installment);
    }

public async Task<Response<string>> AddInstallment(AddInstallmentDto model)
{
    try
    {
        var mapped = _mapper.Map<Installment>(model);
        await _context.Installments.AddAsync(mapped);
        await _context.SaveChangesAsync();
        model.Id = mapped.Id;
        return new Response<string>(_mapper.Map<string>("Installment Added Successfully"));
    }
    catch (Exception ex)
    {
        return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
    }
}
public async Task<Response<AddInstallmentDto>> UpdateInstallment(AddInstallmentDto model)
{
    try
    {
        var record = await _context.Installments.FindAsync(model.Id);
        if (record == null) return new Response<AddInstallmentDto>(System.Net.HttpStatusCode.NotFound, "No record found");
        record.EndInstallement = model.EndInstallement;
        record.Percentage = model.Percentage;
        await _context.SaveChangesAsync();
        return new Response<AddInstallmentDto>(model);
    }
    catch (System.Exception ex)
    {
        return new Response<AddInstallmentDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
    }
}
public async Task<Response<string>> DaleteInstallment(int id)
{
    try
    {
        var record = await _context.Installments.FindAsync(id);
        if (record == null)
            return new Response<string>(System.Net.HttpStatusCode.NotFound, "No record found");
        _context.Installments.Remove(record);
        await _context.SaveChangesAsync();
        return new Response<string>("success");
    }
    catch (System.Exception ex)
    {
        return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
    }
}
}
