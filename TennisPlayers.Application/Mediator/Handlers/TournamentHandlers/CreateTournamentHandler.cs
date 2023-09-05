using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.TournamentCommands;

namespace TennisPlayers.Application.Mediator.Handlers.TournamentHandlers
{
    public class CreateTournamentHandler : IRequestHandler<CreateTournamentCommand, bool>
    {
        private readonly ITournamentService _tournamentService;
        private readonly ILocationService _locationService;
        public CreateTournamentHandler(ITournamentService tournamentService, ILocationService locationService)
        {
            _tournamentService = tournamentService;
            _locationService = locationService;
        }
        public async Task<bool> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
        {
            if (!_locationService.LocationExists(request.LocationId))
                return false;

            return _tournamentService.AddTournament(request.LocationId, request.TournamentDto);
        }
    }
}
