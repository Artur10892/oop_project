using CleanArch_Application.DTO.Responses;
using MediatR;

namespace CleanArch_Application.Queries.Regions.GetByIdRegion
{
    public class GetByIdRegionQuery : IRequest<RegionResponse>
    {
        public int Id { get; set; }
    }
}