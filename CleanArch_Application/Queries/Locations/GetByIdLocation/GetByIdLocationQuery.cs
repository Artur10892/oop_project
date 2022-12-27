using CleanArch_Application.DTO.Responses;
using MediatR;

namespace CleanArch_Application.Queries.Locations.GetByIdLocation
{
    public class GetByIdLocationQuery : IRequest<LocationResponse>
    {
        public int Id { get; set; }
    }
}