using MediatR;

namespace CleanArch_Application.Commands.Locations.DeleteLocation
{
    public class DeleteLocationCommand: IRequest
    {
        public int Id { get; set; }
    }
}