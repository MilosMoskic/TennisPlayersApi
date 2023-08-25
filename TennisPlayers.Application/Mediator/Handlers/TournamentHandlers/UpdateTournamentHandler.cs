using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.TournamentCommands;
using TennisPlayers.Application.Services;

namespace TennisPlayers.Application.Mediator.Handlers.TournamentHandlers
{
    public class UpdateTournamentHandler : IRequestHandler<UpdateTournamentCommand, bool>
    {
        private readonly ITournamentService _tournamentService;
        public UpdateTournamentHandler(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }
        public async Task<bool> Handle(UpdateTournamentCommand request, CancellationToken cancellationToken)
        {
            if (!_tournamentService.TournamentExists(request.TournamentId))
                return false;

            return _tournamentService.UpdateTournament(request.TournamentId, request.TournamentDto);
        }
    }
}
