using AutoMapper;
using CleanArch_Application.DTO.Requests;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Products.InsertProduct
{
    public class InsertProductCommandHandler: IRequestHandler<InsertProductCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Product> _table;

        private readonly IMapper _mapper;

        public InsertProductCommandHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Product>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductPostRequest, Product>(request.ProductPostRequest);
            await _table.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}