using CleanArch_Application.DTO.Requests;
using MediatR;

namespace CleanArch_Application.Commands.Suppliers.UpdateSupplier
{
    public class UpdateSupplierCommand: IRequest
    {
        public SupplierRequest SupplierRequest { get; set; }
    }
}