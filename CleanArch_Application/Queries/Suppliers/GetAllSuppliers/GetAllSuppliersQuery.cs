using CleanArch_Application.DTO.Responses;
using MediatR;

namespace CleanArch_Application.Queries.Suppliers.GetAllSuppliers
{
    public class GetAllSuppliersQuery : IRequest<IEnumerable<SupplierResponse>>
    {
        
    }
}