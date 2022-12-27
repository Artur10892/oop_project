using CleanArch_Application.DTO.Requests;
using MediatR;

namespace CleanArch_Application.Commands.Locations.UpdateLocation
{
    public class UpdateLocationCommand: IRequest
    {
        public LocationRequest LocationRequest { get; set; }
    }
}