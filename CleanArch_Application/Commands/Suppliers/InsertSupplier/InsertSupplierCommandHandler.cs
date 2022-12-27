using AutoMapper;
using CleanArch_Application.DTO.Requests;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Suppliers.InsertSupplier
{
    public class InsertSupplierCommandHandler: IRequestHandler<InsertSupplierCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Supplier> _table;

        private readonly IMapper _mapper;

        public InsertSupplierCommandHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Supplier>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(InsertSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SupplierPostRequest, Supplier>(request.SupplierPostRequest);
            await _table.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}