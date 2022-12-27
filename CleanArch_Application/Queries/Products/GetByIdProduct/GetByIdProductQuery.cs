using CleanArch_Application.DTO.Responses;
using MediatR;

namespace CleanArch_Application.Queries.Products.GetByIdProduct
{
    public class GetByIdProductQuery : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }
}