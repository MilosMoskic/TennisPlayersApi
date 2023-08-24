using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.AthleteQuerries
{
    public class GetAthletesByTournamentQuerry : IRequest<List<AthleteDto>>
    {
        public int TournamentId { get; set; }
        public GetAthletesByTournamentQuerry(int tournamentId)
        {
            TournamentId = tournamentId;
        }
    }
}
