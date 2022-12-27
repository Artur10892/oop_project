using MediatR;

namespace CleanArch_Application.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryCommand: IRequest
    {
        public int Id { get; set; }
    }
}