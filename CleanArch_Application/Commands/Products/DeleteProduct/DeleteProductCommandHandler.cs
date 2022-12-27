using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandHandler: IRequestHandler<DeleteProductCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Product> _table;

        public DeleteProductCommandHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Product>();
        }
        
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var foundEntity = await _table.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(foundEntity == null) 
                throw new EntityNotFoundException(nameof(Product), request.Id);
            
            await Task.Run(() => _table.Remove(foundEntity), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}