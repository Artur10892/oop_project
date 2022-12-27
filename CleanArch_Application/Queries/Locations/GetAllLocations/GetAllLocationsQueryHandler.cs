using AutoMapper;
using CleanArch_Application.DTO.Responses;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Queries.Locations.GetAllLocations
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, IEnumerable<LocationResponse>>
    {
        private readonly DbSet<Location> _table;
        
        private readonly IMapper _mapper;

        public GetAllLocationsQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _table = dbContext.Set<Location>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocationResponse>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            var results = await _table
                .Include(location => location.RegionNavigation)
                .ToListAsync(cancellationToken);
            return results.Select(_mapper.Map<Location, LocationResponse>);
        }
    }
}