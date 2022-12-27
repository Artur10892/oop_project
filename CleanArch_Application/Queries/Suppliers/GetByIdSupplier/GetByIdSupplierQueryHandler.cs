using AutoMapper;
using CleanArch_Application.DTO.Responses;
using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Queries.Suppliers.GetByIdSupplier
{
    public class GetByIdSupplierQueryHandler : IRequestHandler<GetByIdSupplierQuery, SupplierResponse>
    {
        private readonly DbSet<Supplier> _table;
        
        private readonly IMapper _mapper;

        public GetByIdSupplierQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _table = dbContext.Set<Supplier>();
            _mapper = mapper;
        }


        public async Task<SupplierResponse> Handle(GetByIdSupplierQuery request, CancellationToken cancellationToken)
        {
            var result = await _table
                             .Include(supplier => supplier.Location)
                                .ThenInclude(location => location.RegionNavigation)
                             .SingleOrDefaultAsync(supplier => supplier.Id == request.Id, cancellationToken)
                         ?? throw new EntityNotFoundException(nameof(Supplier), request.Id);

            return _mapper.Map<Supplier, SupplierResponse>(result);
        }
    }
}