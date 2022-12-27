using CleanArch_Application.DTO.Responses;
using MediatR;

namespace CleanArch_Application.Queries.Regions.GetAllRegions
{
    public class GetAllRegionsQuery : IRequest<IEnumerable<RegionResponse>>
    {
        
    }
}