using MediatR;

namespace CleanArch_Application.Commands.Suppliers.DeleteSupplier
{
    public class DeleteSupplierCommand: IRequest
    {
        public int Id { get; set; }
    }
}