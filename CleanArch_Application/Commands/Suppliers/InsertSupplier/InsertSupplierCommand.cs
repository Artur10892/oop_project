using CleanArch_Application.DTO.Requests;
using MediatR;

namespace CleanArch_Application.Commands.Suppliers.InsertSupplier
{
    public class InsertSupplierCommand: IRequest
    {
        public SupplierPostRequest SupplierPostRequest { get; set; }
    }
}