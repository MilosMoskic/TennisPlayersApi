using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.AthleteQuerries
{
    public class GetAthleteByRankingQuerry : IRequest<AthleteDto>
    {
        public int Ranking { get; set; }
        public GetAthleteByRankingQuerry(int ranking)
        {
            Ranking = ranking;
        }
    }
}
