using AutoMapper;
using CleanArch_Application.DTO.Requests;
using CleanArch_Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_Application.Commands.Locations.InsertLocation
{
    public class InsertLocationCommandHandler: IRequestHandler<InsertLocationCommand>
    {
        private readonly DbContext _dbContext;
        
        private readonly DbSet<Location> _table;

        private readonly IMapper _mapper;

        public InsertLocationCommandHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Location>();
            _mapper = mapper;
        }

        public async Task<Unit> Handle(InsertLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<LocationPostRequest, Location>(request.LocationPostRequest);
            await _table.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}