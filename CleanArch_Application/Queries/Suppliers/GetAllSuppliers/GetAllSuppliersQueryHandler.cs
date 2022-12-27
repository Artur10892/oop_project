using AutoMapper;
using CleanArch_Application.DTO.Responses;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Queries.Suppliers.GetAllSuppliers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, IEnumerable<SupplierResponse>>
    {
        private readonly DbSet<Supplier> _table;
        
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _table = dbContext.Set<Supplier>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplierResponse>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var results = await _table
                .Include(supplier => supplier.Location)
                    .ThenInclude(location => location.RegionNavigation)
                .ToListAsync(cancellationToken);
            
            return results.Select(_mapper.Map<Supplier, SupplierResponse>);
        }
    }
}