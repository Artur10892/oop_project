using MediatR;

namespace CleanArch_Application.Commands.Regions.DeleteRegion
{
    public class DeleteRegionCommand: IRequest
    {
        public int Id { get; set; }
    }
}