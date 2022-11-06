using AutoMapper;
using Domain.Dtos;
using Domain.Entites;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Response<List<GetCustomerPurchacesDto>>> GetCustomerPurchaces()
    {
        var customer = await (from cp in _context.CustomerPurchaces
                              join cu in _context.Customers
                              on cp.CustomersId equals cu.Id
                              join ic in _context.Installments
                              on cp.InstallmentId equals ic.Id
                              select new GetCustomerPurchacesDto
                              {
                                  Id = cp.Id,
                                  InstallmentId = ic.Id,
                                  CustomersName = cu.Name
                              }).ToListAsync();
        return new Response<List<GetCustomerPurchacesDto>>(customer);
    }

    public async Task<Response<AddCustomerPurchacesDto>> AddCustomerPurchaces(AddCustomerPurchacesDto model)
    {
        try
        {
            var mapped = _mapper.Map<CustomerPurchaces>(model);
            await _context.CustomerPurchaces.AddAsync(mapped);
            await _context.SaveChangesAsync();
            model.Id = mapped.Id;
            return new Response<AddCustomerPurchacesDto>(_mapper.Map<AddCustomerPurchacesDto>("Installment Added Successfully"));
        }
        catch (Exception ex)
        {
            return new Response<AddCustomerPurchacesDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddCustomerPurchacesDto>> UpdateCustomerPurchaces(AddCustomerPurchacesDto model)
    {
        try
        {
            var record = await _context.CustomerPurchaces.FindAsync(model.Id);
            if (record == null) return new Response<AddCustomerPurchacesDto>(System.Net.HttpStatusCode.NotFound, "No record found");
            record.Id = model.Id;
            await _context.SaveChangesAsync();
            return new Response<AddCustomerPurchacesDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddCustomerPurchacesDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> DaleteCustomerPurchaces(int id)
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
