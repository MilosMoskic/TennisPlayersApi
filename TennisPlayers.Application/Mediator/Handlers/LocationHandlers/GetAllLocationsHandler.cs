using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.LocationQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.LocationHandlers
{
    public class GetAllLocationsHandler : IRequestHandler<GetAllLocationsQuerry, List<LocationDto>>
    {
        private readonly ILocationService _locationService;
        public GetAllLocationsHandler(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public Task<List<LocationDto>> Handle(GetAllLocationsQuerry request, CancellationToken cancellationToken)
        {
            return _locationService.GetAllLocations();
        }
    }
}
