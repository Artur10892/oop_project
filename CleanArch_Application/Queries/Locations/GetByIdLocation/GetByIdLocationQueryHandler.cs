using AutoMapper;
using CleanArch_Application.DTO.Responses;
using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Queries.Locations.GetByIdLocation
{
    public class GetByIdLocationQueryHandler : IRequestHandler<GetByIdLocationQuery, LocationResponse>
    {
        private readonly DbSet<Location> _table;
        
        private readonly IMapper _mapper;

        public GetByIdLocationQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _table = dbContext.Set<Location>();
            _mapper = mapper;
        }


        public async Task<LocationResponse> Handle(GetByIdLocationQuery request, CancellationToken cancellationToken)
        {
            var result = await _table
                             .Include(location => location.RegionNavigation)
                             .SingleOrDefaultAsync(location => location.Id == request.Id, cancellationToken) 
                         ?? throw new EntityNotFoundException(nameof(Location), request.Id);

            return _mapper.Map<Location, LocationResponse>(result);
        }
    }
}