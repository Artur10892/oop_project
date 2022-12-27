using AutoMapper;
using CleanArch_Application.DTO.Requests;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Categories.InsertCategory
{
    public class InsertCategoryCommandHandler: IRequestHandler<InsertCategoryCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Category> _table;

        private readonly IMapper _mapper;

        public InsertCategoryCommandHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Category>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(InsertCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CategoryPostRequest, Category>(request.CategoryPostRequest);
            await _table.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}