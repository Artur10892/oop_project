using AutoMapper;
using CleanArch_Application.DTO.Requests;
using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommandHandler: IRequestHandler<UpdateCategoryCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Category> _table;
        
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Category>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CategoryRequest, Category>(request.CategoryRequest);
            var foundEntity = 
                await _table.AsNoTracking().AnyAsync(x => x.Id == entity.Id, cancellationToken);
            if(!foundEntity)
                throw new EntityNotFoundException(nameof(Category), entity.Id);

            await Task.Run(() => _table.Update(entity), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}