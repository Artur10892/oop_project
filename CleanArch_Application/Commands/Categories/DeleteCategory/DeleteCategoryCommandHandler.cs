using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryCommandHandler: IRequestHandler<DeleteCategoryCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Category> _table;

        public DeleteCategoryCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Category>();
        }
        
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var foundEntity = await _table.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(foundEntity == null) 
                throw new EntityNotFoundException(nameof(Category), request.Id);
            
            await Task.Run(() => _table.Remove(foundEntity), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}