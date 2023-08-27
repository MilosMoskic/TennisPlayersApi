using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.LocationCommands;
using TennisPlayers.Application.Services;

namespace TennisPlayers.Application.Mediator.Handlers.LocationHandlers
{
    public class DeleteLocationHandler : IRequestHandler<DeleteLocationCommand, bool>
    {
        public readonly ILocationService _locationService;
        public DeleteLocationHandler(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<bool> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            if (!_locationService.LocationExists(request.LocationId))
                return false;

            var locationToDelete = await _locationService.GetLocationByLocationIdAsNoTracking(request.LocationId);

            return _locationService.DeleteLocation(locationToDelete);
        }
    }
}
