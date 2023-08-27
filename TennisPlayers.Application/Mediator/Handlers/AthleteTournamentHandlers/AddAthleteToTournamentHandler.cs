using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.AthleteTournamentCommands;

namespace TennisPlayers.Application.Mediator.Handlers.AthleteTournamentHandlers
{
    public class AddAthleteToTournamentHandler : IRequestHandler<AddAthleteToTournamentCommand, bool>
    {
        private readonly IAthleteService _athleteService;
        private readonly ITournamentService _tournamentService;
        private readonly IAthleteTournamentService _athleteTournamentService;
        public AddAthleteToTournamentHandler(ITournamentService tournamentService,
            IAthleteService athleteService,
            IAthleteTournamentService athleteTournamentService)
        {
            _athleteService = athleteService;
            _tournamentService = tournamentService;
            _athleteTournamentService = athleteTournamentService;
        }

        public async Task<bool> Handle(AddAthleteToTournamentCommand request, CancellationToken cancellationToken)
        {
            if (!_athleteService.AthleteExists(request.AthleteId))
                return false;

            if (!_tournamentService.TournamentExists(request.TournamentId))
                return false;

            return _athleteTournamentService.AddAthleteToTournament(request.AthleteId, request.TournamentId, request.AthleteTournamentDto);

        }
    }
}
