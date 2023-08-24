using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;

namespace TennisPlayers.Application.Mediator.Querries.AthleteQuerries
{
    public class GetAthleteByRankingHandler : IRequestHandler<GetAthleteByRankingQuerry, AthleteDto>
    {
        private readonly IAthleteService _athleteService;
        public GetAthleteByRankingHandler(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }
        public async Task<AthleteDto> Handle(GetAthleteByRankingQuerry request, CancellationToken cancellationToken)
        {
            return _athleteService.GetAthleteByRanking(request.Ranking);
        }
    }
}
