using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Locations.DeleteLocation
{
    public class DeleteLocationCommandHandler: IRequestHandler<DeleteLocationCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Location> _table;

        public DeleteLocationCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Location>();
        }
        
        public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var foundEntity = await _table.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(foundEntity == null) 
                throw new EntityNotFoundException(nameof(Location), request.Id);
            
            await Task.Run(() => _table.Remove(foundEntity), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}