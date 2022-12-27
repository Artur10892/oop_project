using MediatR;

namespace CleanArch_Application.Commands.Products.DeleteProduct
{
    public class DeleteProductCommand: IRequest
    {
        public int Id { get; set; }
    }
}