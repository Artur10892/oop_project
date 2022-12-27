using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Regions.DeleteRegion
{
    public class DeleteRegionCommandHandler: IRequestHandler<DeleteRegionCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Region> _table;

        public DeleteRegionCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Region>();
        }
        
        public async Task<Unit> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
        {
            var foundEntity = await _table.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(foundEntity == null) 
                throw new EntityNotFoundException(nameof(Region), request.Id);
            
            await Task.Run(() => _table.Remove(foundEntity), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}