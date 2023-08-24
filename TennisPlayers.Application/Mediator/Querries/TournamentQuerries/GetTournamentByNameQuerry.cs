using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.TournamentQuerries
{
    public class GetTournamentByNameQuerry : IRequest<TournamentDto>
    {
        public string Name { get; set; }
        public GetTournamentByNameQuerry(string name)
        {
            Name = name;
        }
    }
}
