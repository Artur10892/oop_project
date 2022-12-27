using CleanArch_Application.DTO.Responses;
using MediatR;

namespace CleanArch_Application.Queries.Suppliers.GetByIdSupplier
{
    public class GetByIdSupplierQuery : IRequest<SupplierResponse>
    {
        public int Id { get; set; }
    }
}