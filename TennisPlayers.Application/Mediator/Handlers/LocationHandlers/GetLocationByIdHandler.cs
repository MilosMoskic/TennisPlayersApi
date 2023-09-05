using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.LocationQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdHandler : IRequestHandler<GetLocationByIdQuerry, LocationDto>
    {
        private readonly ILocationService _locationService;
        public GetLocationByIdHandler(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<LocationDto> Handle(GetLocationByIdQuerry request, CancellationToken cancellationToken)
        {
            return _locationService.GetLocationById(request.LocationId);
        }
    }
}
