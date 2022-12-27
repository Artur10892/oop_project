using CleanArch_Application.DTO.Requests;
using MediatR;

namespace CleanArch_Application.Commands.Products.SetImageToProduct
{
    public class SetImageToProductCommand: IRequest
    {
        public ImageUploadRequest ImageUploadRequest { get; set; }
    }
}