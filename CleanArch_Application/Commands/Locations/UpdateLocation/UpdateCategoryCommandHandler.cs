using AutoMapper;
using CleanArch_Application.DTO.Requests;
using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Locations.UpdateLocation
{
    public class UpdateLocationCommandHandler: IRequestHandler<UpdateLocationCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Location> _table;
        
        private readonly IMapper _mapper;

        public UpdateLocationCommandHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Location>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<LocationRequest, Location>(request.LocationRequest);
            var foundEntity = 
                await _table.AsNoTracking().AnyAsync(x => x.Id == entity.Id, cancellationToken);
            if(!foundEntity)
                throw new EntityNotFoundException(nameof(Location), entity.Id);

            await Task.Run(() => _table.Update(entity), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}