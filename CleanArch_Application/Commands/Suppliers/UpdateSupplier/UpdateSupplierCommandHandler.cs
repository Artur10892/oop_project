using AutoMapper;
using CleanArch_Application.DTO.Requests;
using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Suppliers.UpdateSupplier
{
    public class UpdateSupplierCommandHandler: IRequestHandler<UpdateSupplierCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Supplier> _table;
        
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Supplier>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SupplierRequest, Supplier>(request.SupplierRequest);
            var foundEntity = 
                await _table.AsNoTracking().AnyAsync(x => x.Id == entity.Id, cancellationToken);
            if(!foundEntity)
                throw new EntityNotFoundException(nameof(Supplier), entity.Id);

            await Task.Run(() => _table.Update(entity), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}