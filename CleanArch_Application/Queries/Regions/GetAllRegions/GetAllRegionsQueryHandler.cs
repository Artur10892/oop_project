using AutoMapper;
using CleanArch_Application.DTO.Responses;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Queries.Regions.GetAllRegions
{
    public class GetAllRegionsQueryHandler : IRequestHandler<GetAllRegionsQuery, IEnumerable<RegionResponse>>
    {
        private readonly DbSet<Region> _table;
        
        private readonly IMapper _mapper;

        public GetAllRegionsQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _table = dbContext.Set<Region>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegionResponse>> Handle(GetAllRegionsQuery request, CancellationToken cancellationToken)
        {
            var results = await _table.ToListAsync(cancellationToken);
            return results.Select(_mapper.Map<Region, RegionResponse>);
        }
    }
}