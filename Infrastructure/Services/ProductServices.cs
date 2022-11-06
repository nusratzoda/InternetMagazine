using AutoMapper;
using Domain.Dtos;
using Domain.Entites;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services;
public class ProductServices : IProductServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ProductServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetProductDto>>> GetProduct()
    {

        var installment = await (from ins in _context.Products
                                 select new GetProductDto()
                                 {
                                     Name = ins.Name,
                                     Id = ins.Id,
                                     Price = ins.Price,
                                     Installments = (from cu in _context.Installments
                                                          where ins.Id == cu.ProductId
                                                          select _mapper.Map<Installment>(cu)
                                                     ).ToList()

                                 }).ToListAsync();
        return new Response<List<GetProductDto>>(installment);
    }

    public async Task<Response<AddProductDto>> AddProduct(AddProductDto model)
    {
        try
        {
            var mapped = _mapper.Map<Product>(model);
            await _context.Products.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddProductDto>(_mapper.Map<AddProductDto>("Installment Added Successfully"));
        }
        catch (Exception ex)
        {
            return new Response<AddProductDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<AddProductDto>> UpdateProduct(AddProductDto model)
    {
        try
        {
            var record = await _context.Products.FindAsync(model.Id);
            if (record == null) return new Response<AddProductDto>(System.Net.HttpStatusCode.NotFound, "No record found");
            await _context.SaveChangesAsync();
            return new Response<AddProductDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddProductDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> DaleteProduct(int id)
    {
        try
        {
            var record = await _context.Products.FindAsync(id);
            if (record == null)
                return new Response<string>(System.Net.HttpStatusCode.NotFound, "No record found");
            _context.Products.Remove(record);
            await _context.SaveChangesAsync();
            return new Response<string>("success");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
