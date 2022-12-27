using AutoMapper;
using CleanArch_Application.DTO.Requests;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Regions.InsertRegion
{
    public class InsertRegionCommandHandler: IRequestHandler<InsertRegionCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Region> _table;

        private readonly IMapper _mapper;

        public InsertRegionCommandHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Region>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(InsertRegionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<RegionPostRequest, Region>(request.RegionPostRequest);
            await _table.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}