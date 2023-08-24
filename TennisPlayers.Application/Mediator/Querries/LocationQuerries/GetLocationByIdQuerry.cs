using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.LocationQuerries
{
    public class GetLocationByIdQuerry : IRequest<LocationDto>
    {
        public int LocationId { get; set; }
        public GetLocationByIdQuerry(int locationId)
        {
            LocationId = locationId;
        }
    }
}
