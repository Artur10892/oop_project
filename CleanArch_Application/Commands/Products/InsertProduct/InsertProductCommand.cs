using CleanArch_Application.DTO.Requests;
using MediatR;

namespace CleanArch_Application.Commands.Products.InsertProduct
{
    public class InsertProductCommand: IRequest
    {
        public ProductPostRequest ProductPostRequest { get; set; }
    }
}