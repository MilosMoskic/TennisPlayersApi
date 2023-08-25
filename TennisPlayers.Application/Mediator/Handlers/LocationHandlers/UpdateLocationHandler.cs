using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.LocationCommands;
using TennisPlayers.Application.Services;

namespace TennisPlayers.Application.Mediator.Handlers.LocationHandlers
{
    public class UpdateLocationHandler : IRequestHandler<UpdateLocationCommand, bool>
    {
        private readonly ILocationService _locationService;
        public UpdateLocationHandler(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public async Task<bool> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            if (!_locationService.LocationExists(request.LocationId))
                return false;

            return _locationService.UpdateLocation(request.LocationId, request.LocationDto);
        }
    }
}
