using CleanArch_Application.DTO.Responses;
using MediatR;

namespace CleanArch_Application.Queries.Locations.GetAllLocations
{
    public class GetAllLocationsQuery : IRequest<IEnumerable<LocationResponse>>
    {
        
    }
}