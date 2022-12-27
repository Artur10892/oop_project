using AutoMapper;
using CleanArch_Application.DTO.Requests;
using CleanArch_Application.Exceptions;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Regions.UpdateRegion
{
    public class UpdateRegionCommandHandler: IRequestHandler<UpdateRegionCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Region> _table;
        
        private readonly IMapper _mapper;

        public UpdateRegionCommandHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Region>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<RegionRequest, Region>(request.RegionRequest);
            var foundEntity = 
                await _table.AsNoTracking().AnyAsync(x => x.Id == entity.Id, cancellationToken);
            if(!foundEntity)
                throw new EntityNotFoundException(nameof(Region), entity.Id);

            await Task.Run(() => _table.Update(entity), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}