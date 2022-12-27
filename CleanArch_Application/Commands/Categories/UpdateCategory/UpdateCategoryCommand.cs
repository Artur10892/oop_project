using CleanArch_Application.DTO.Requests;
using MediatR;

namespace CleanArch_Application.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommand: IRequest
    {
        public CategoryRequest CategoryRequest { get; set; }
    }
}