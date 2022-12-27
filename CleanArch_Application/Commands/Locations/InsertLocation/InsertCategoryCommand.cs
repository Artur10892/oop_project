using CleanArch_Application.DTO.Requests;
using MediatR;

namespace CleanArch_Application.Commands.Locations.InsertLocation
{
    public class InsertLocationCommand: IRequest
    {
        public LocationPostRequest LocationPostRequest { get; set; }
    }
}