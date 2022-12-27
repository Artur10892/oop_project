using CleanArch_Application.DTO.Requests;
using MediatR;

namespace CleanArch_Application.Commands.Regions.UpdateRegion
{
    public class UpdateRegionCommand: IRequest
    {
        public RegionRequest RegionRequest { get; set; }
    }
}