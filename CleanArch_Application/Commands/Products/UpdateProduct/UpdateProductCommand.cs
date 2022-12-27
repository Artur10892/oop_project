using CleanArch_Application.DTO.Requests;
using MediatR;

namespace CleanArch_Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommand: IRequest
    {
        public ProductRequest ProductRequest { get; set; }
    }
}