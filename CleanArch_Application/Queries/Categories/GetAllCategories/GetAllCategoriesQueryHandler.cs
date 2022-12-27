using MediatR;
using AutoMapper;
using CleanArch_Application.DTO.Responses;
using CleanArch_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryResponse>>
    {
        private readonly DbSet<Category> _table;
        
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _table = dbContext.Set<Category>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var results = await _table.ToListAsync(cancellationToken);
            return results.Select(_mapper.Map<Category, CategoryResponse>);
        }
    }
}