using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.AthleteTournamentQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.AthleteTournamentHandlers
{
    public class GetAthletesByTournamentHandler : IRequestHandler<GetAthletesByTournamentQuerry, List<AthleteDto>>
    {
        private readonly IAthleteTournamentService _athleteTournamentService;
        public GetAthletesByTournamentHandler(IAthleteTournamentService athleteTournamentService)
        {
            _athleteTournamentService = athleteTournamentService;
        }
        public async Task<List<AthleteDto>> Handle(GetAthletesByTournamentQuerry request, CancellationToken cancellationToken)
        {
            return await _athleteTournamentService.GetAthletesByTournament(request.TournamentId);
        }
    }
}
