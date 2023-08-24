using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.LocationQuerries
{
    public class GetAllLocationsQuerry : IRequest<List<LocationDto>>
    {
    }
}
