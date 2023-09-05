using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.TournamentCommands;

namespace TennisPlayers.Application.Mediator.Handlers.TournamentHandlers
{
    public class DeleteTournamentHandler : IRequestHandler<DeleteTournamentCommand, bool>
    {
        private readonly ITournamentService _tournamentService;
        public DeleteTournamentHandler(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }
        public async Task<bool> Handle(DeleteTournamentCommand request, CancellationToken cancellationToken)
        {
            if (!_tournamentService.TournamentExists(request.TournamentId))
                return false;

            var sponsorToDelete = await _tournamentService.GetTournamentByTournamentIdAsNoTracking(request.TournamentId);

            return _tournamentService.DeleteTournament(sponsorToDelete);
        }
    }
}
