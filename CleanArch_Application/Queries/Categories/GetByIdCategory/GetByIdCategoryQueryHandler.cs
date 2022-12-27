using AutoMapper;
using CleanArch_Application.DTO.Responses;
using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Queries.Categories.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryResponse>
    {
        private readonly DbSet<Category> _table;
        
        private readonly IMapper _mapper;

        public GetByIdCategoryQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _table = dbContext.Set<Category>();
            _mapper = mapper;
        }


        public async Task<CategoryResponse> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _table.FindAsync(new object?[] { request.Id }, cancellationToken)
                   ?? throw new EntityNotFoundException(nameof(Category), request.Id);

            return _mapper.Map<Category, CategoryResponse>(result);
        }
    }
}