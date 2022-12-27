using AutoMapper;
using CleanArch_Application.DTO.Responses;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Queries.Products.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponse>>
    {
        private readonly DbSet<Product> _products;
        
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _products = dbContext.Set<Product>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var results = await _products
                .Include(product => product.Supplier)
                .Include(product => product.Category)
                .ToListAsync(cancellationToken);
            
            var extendedResults = new List<ProductResponse>();
            foreach (var result in results)
            {
                var temp = _mapper.Map<Product, ProductResponse>(result);
                throw new NotImplementedException("Implement warehouseProducts using gRPC");
                // temp.Quantity = await _warehouseProducts
                //     .Where(warehouseProduct => warehouseProduct.ProductId == temp.Id)
                //     .SumAsync(warehouseProduct => warehouseProduct.Quantity, cancellationToken: cancellationToken);
                extendedResults.Add(temp);
            }

            return extendedResults;
        }
    }
}