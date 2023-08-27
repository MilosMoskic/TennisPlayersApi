using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.AthleteQuerries;
using TennisPlayers.Application.Mediator.Querries.AthleteTournamentQuerries;
using TennisPlayers.Domain.Models;

namespace TennisPlayers.Application.Mediator.Handlers.AthleteTournamentHandlers
{
    public class GetAthletesByTournamentHandler : IRequestHandler<GetAthletesByTournamentQuerry, List<AthleteDto>>
    {
        private readonly IAthleteTournamentService _athleteTournamentService;
        private readonly ITournamentService _tournamentService;
        public GetAthletesByTournamentHandler(ITournamentService tournamentService, IAthleteTournamentService athleteTournamentService)
        {
            _tournamentService = tournamentService;
            _athleteTournamentService = athleteTournamentService;
        }
        public async Task<List<AthleteDto>> Handle(GetAthletesByTournamentQuerry request, CancellationToken cancellationToken)
        {
            return await _athleteTournamentService.GetAthletesByTournament(request.TournamentId);
        }
    }
}
