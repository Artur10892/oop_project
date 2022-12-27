using AutoMapper;
using CleanArch_Application.DTO.Requests;
using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Product> _table;
        
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Product>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductRequest, Product>(request.ProductRequest);
            var foundEntity = 
                await _table.AsNoTracking().AnyAsync(x => x.Id == entity.Id, cancellationToken);
            if(!foundEntity)
                throw new EntityNotFoundException(nameof(Product), entity.Id);

            await Task.Run(() => _table.Update(entity), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}