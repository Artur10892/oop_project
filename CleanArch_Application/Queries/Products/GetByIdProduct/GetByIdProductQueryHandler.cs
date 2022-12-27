using AutoMapper;
using CleanArch_Application.DTO.Responses;
using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Queries.Products.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductResponse>
    {
        private readonly DbSet<Product> _products;
        
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _products = dbContext.Set<Product>();
            _mapper = mapper;
        }


        public async Task<ProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _products
                             .Include(product => product.Supplier)
                             .Include(product => product.Category)
                             .SingleOrDefaultAsync(product => product.Id == request.Id , cancellationToken)
                         ?? throw new EntityNotFoundException(nameof(Product), request.Id);

            var extendedResult = _mapper.Map<Product, ProductResponse>(result);
            throw new NotImplementedException("Implement warehouseProducts using gRPC");
            // extendedResult.Quantity = await _warehouseProducts
            //     .Where(warehouseProduct => warehouseProduct.ProductId == result.Id)
            //     .SumAsync(warehouseProduct => warehouseProduct.Quantity, cancellationToken: cancellationToken);

            return extendedResult;
        }
    }
}