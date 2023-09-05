using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.TournamentQuerries
{
    public class GetTournamentByIdQuerry : IRequest<TournamentDto>
    {
        public int TournamentId { get; set; }
        public GetTournamentByIdQuerry(int tournamentId)
        {
            TournamentId = tournamentId;
        }
    }
}
