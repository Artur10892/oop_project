using CleanArch_Application.DTO.Requests;
using MediatR;

namespace CleanArch_Application.Commands.Regions.InsertRegion
{
    public class InsertRegionCommand: IRequest
    {
        public RegionPostRequest RegionPostRequest { get; set; }
    }
}