using AutoMapper;
using CleanArch_Application.DTO.Responses;
using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Queries.Regions.GetByIdRegion
{
    public class GetByIdRegionQueryHandler : IRequestHandler<GetByIdRegionQuery, RegionResponse>
    {
        private readonly DbSet<Region> _table;
        
        private readonly IMapper _mapper;

        public GetByIdRegionQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _table = dbContext.Set<Region>();
            _mapper = mapper;
        }


        public async Task<RegionResponse> Handle(GetByIdRegionQuery request, CancellationToken cancellationToken)
        {
            var result = await _table.FindAsync(new object?[] { request.Id }, cancellationToken)
                   ?? throw new EntityNotFoundException(nameof(Region), request.Id);

            return _mapper.Map<Region, RegionResponse>(result);
        }
    }
}