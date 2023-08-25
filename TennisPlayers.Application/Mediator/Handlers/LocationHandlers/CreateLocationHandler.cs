using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.LocationCommands;

namespace TennisPlayers.Application.Mediator.Handlers.LocationHandlers
{
    public class CreateLocationHandler : IRequestHandler<CreateLocationCommand, bool>
    {
        private readonly ILocationService _locationService;
        public CreateLocationHandler(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<bool> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            return _locationService.AddLocation(request.LocationDto);
        }
    }
}
