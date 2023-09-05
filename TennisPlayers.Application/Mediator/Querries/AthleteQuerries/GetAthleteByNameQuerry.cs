using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.AthleteQuerries
{
    public class GetAthleteByNameQuerry : IRequest<AthleteDto>
    {
        public string Name { get; set; }
        public GetAthleteByNameQuerry(string name)
        {
            Name = name;
        }
    }
}
