using AutoMapper;
using Domain.Dtos;
using Domain.Entites;
using Domain.Wrapper;
using Infrastructure.Context;
namespace Infrastructure.Services;
public class CustomerPurchacesServices : ICustomerPurchacesServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CustomerPurchacesServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<string>> AddCustomerPurchaces(AddCustomerPurchacesDto model)
    {
        try
        {
            var mapped = _mapper.Map<CustomerPurchaces>(model);
            await _context.CustomerPurchaces.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<string>(_mapper.Map<string>("Installment Added Successfully"));
        }
        catch (Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddCustomerPurchacesDto>> UpdateCustomerPurchaces(AddCustomerPurchacesDto model)
    {
        try
        {
            var record = await _context.CustomerPurchaces.FindAsync(model.Id);
            if (record == null) return new Response<AddCustomerPurchacesDto>(System.Net.HttpStatusCode.NotFound, "No record found");
            await _context.SaveChangesAsync();
            return new Response<AddCustomerPurchacesDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddCustomerPurchacesDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> DaleteInstallment(int id)
    {
        try
        {
            var record = await _context.Customers.FindAsync(id);
            if (record == null)
                return new Response<string>(System.Net.HttpStatusCode.NotFound, "No record found");
            _context.Customers.Remove(record);
            await _context.SaveChangesAsync();
            return new Response<string>("success");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
