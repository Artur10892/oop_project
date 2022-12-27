using CleanArch_Application.DTO.Responses;
using MediatR;

namespace CleanArch_Application.Queries.Categories.GetByIdCategory
{
    public class GetByIdCategoryQuery : IRequest<CategoryResponse>
    {
        public int Id { get; set; }
    }
}