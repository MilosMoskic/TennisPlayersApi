using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.AthleteTournamentCommands;

namespace TennisPlayers.Application.Mediator.Handlers.AthleteTournamentHandlers
{
    public class RemoveAthleteFromTournamentHandler : IRequestHandler<RemoveAthleteFromTournamentCommand, bool>
    {
        private readonly IAthleteService _athleteService;
        private readonly ITournamentService _tournamentService;
        private readonly IAthleteTournamentService _athleteTournamentService;
        public RemoveAthleteFromTournamentHandler(
            IAthleteService athleteService,
            ITournamentService tournamentService,
            IAthleteTournamentService athleteTournamentService)
        {
            _athleteService = athleteService;
            _tournamentService = tournamentService;
            _athleteTournamentService = athleteTournamentService;
        }

        public async Task<bool> Handle(RemoveAthleteFromTournamentCommand request, CancellationToken cancellationToken)
        {
            if (!_athleteService.AthleteExists(request.AthleteId))
                return false;

            if (!_tournamentService.TournamentExists(request.TournamentId))
                return false;

            return _athleteTournamentService.RemoveAthleteFromTournament(request.AthleteId, request.TournamentId);
        }
    }
}
