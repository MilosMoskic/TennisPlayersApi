using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.LocationQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByNameHandler : IRequestHandler<GetLocationByNameQuerry, LocationDto>
    {
        private readonly ILocationService _locationService;
        public GetLocationByNameHandler(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<LocationDto> Handle(GetLocationByNameQuerry request, CancellationToken cancellationToken)
        {
            return _locationService.GetLocationByName(request.Name);
        }
    }
}
