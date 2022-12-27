using CleanArch_Application.DTO.Responses;
using MediatR;

namespace CleanArch_Application.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryResponse>>
    {
        
    }
}