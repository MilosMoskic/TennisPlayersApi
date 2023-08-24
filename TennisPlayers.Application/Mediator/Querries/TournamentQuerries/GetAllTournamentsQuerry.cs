using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.TournamentQuerries
{
    public class GetAllTournamentsQuerry : IRequest<List<TournamentDto>>
    {
    }
}
