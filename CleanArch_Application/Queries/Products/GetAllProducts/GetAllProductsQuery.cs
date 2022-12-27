using CleanArch_Application.DTO.Responses;
using MediatR;

namespace CleanArch_Application.Queries.Products.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductResponse>>
    {
        
    }
}