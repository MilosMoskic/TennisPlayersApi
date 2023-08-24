using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.AthleteQuerries
{
    public class GetAthleteWinPercentQuerry : IRequest<decimal>
    {
        public string LastName { get; set; }
        public GetAthleteWinPercentQuerry(string lastName)
        {
            LastName = lastName;
        }
    }
}
