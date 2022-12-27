using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Suppliers.DeleteSupplier
{
    public class DeleteSupplierCommandHandler: IRequestHandler<DeleteSupplierCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Supplier> _table;

        public DeleteSupplierCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Supplier>();
        }
        
        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var foundEntity = await _table.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(foundEntity == null) 
                throw new EntityNotFoundException(nameof(Supplier), request.Id);
            
            await Task.Run(() => _table.Remove(foundEntity), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}