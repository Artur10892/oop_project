using CleanArch_Application.DTO.Requests;
using MediatR;

namespace CleanArch_Application.Commands.Categories.InsertCategory
{
    public class InsertCategoryCommand: IRequest
    {
        public CategoryPostRequest CategoryPostRequest { get; set; }
    }
}