using AutoMapper;
using CleanArch_Application.Exceptions;
using CleanArch_Application.Protos;
using CleanArch_Domain.Entities;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Infrastructure.Grpc;

public class ProductsService : Products.ProductsBase
{
    private readonly DbSet<Product> _products;
        
    private readonly IMapper _mapper;

    public ProductsService(DbContext dbContext, IMapper mapper)
    {
        _products = dbContext.Set<Product>();
        _mapper = mapper;
    }
    
    public override async Task<ProductsResponse> GetAll(GetAllProductsRequest request, ServerCallContext context)
    {
        var productsResponse = new ProductsResponse();
        var results = await _products
            .Include(product => product.Supplier)
            .Include(product => product.Category)
            .ToListAsync();
            
        var extendedResults = 
            results.Select(result => _mapper.Map<Product, ProductResponse>(result)).ToList();

        productsResponse.Data.AddRange(extendedResults);
        return productsResponse;
    }

    public override async Task<ProductResponse> GetById(GetProductByIdRequest request, ServerCallContext context)
    {
        try
        {
            var product = await _products
                             .Include(product => product.Supplier)
                             .Include(product => product.Category)
                             .SingleOrDefaultAsync(product => product.Id == request.Id)
                         ?? throw new EntityNotFoundException(nameof(Product), request.Id);

            return _mapper.Map<Product, ProductResponse>(product);
        }
        catch (EntityNotFoundException e)
        {
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }
}