using AutoMapper;
using Domain.Dtos;
using Domain.Entites;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services;
public class CustomersServices : ICustomersServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CustomersServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetCustomerDto>>> GetCustomer()
    {

        var installment = await (from ins in _context.Customers
                                 select new GetCustomerDto()
                                 {
                                     Name = ins.Name,
                                     Id = ins.Id,
                                     PhoneNumber = ins.PhoneNumber,
                                     CustomerPurchaces = (from cu in _context.CustomerPurchaces
                                                          where ins.Id == cu.CustomersId
                                                          select _mapper.Map<CustomerPurchaces>(cu)
                                                     ).ToList()

                                 }).ToListAsync();
        return new Response<List<GetCustomerDto>>(installment);
    }

    public async Task<Response<AddCustomerDto>> AddCustomer(AddCustomerDto model)
    {
        try
        {
            var mapped = _mapper.Map<Customers>(model);
            await _context.Customers.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddCustomerDto>(_mapper.Map<AddCustomerDto>("Installment Added Successfully"));
        }
        catch (Exception ex)
        {
            return new Response<AddCustomerDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddCustomerDto>> UpdateCustomer(AddCustomerDto model)
    {
        try
        {
            var record = await _context.Customers.FindAsync(model.Id);
            if (record == null) return new Response<AddCustomerDto>(System.Net.HttpStatusCode.NotFound, "No record found");
            await _context.SaveChangesAsync();
            return new Response<AddCustomerDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddCustomerDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> DaleteCustomer(int id)
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
