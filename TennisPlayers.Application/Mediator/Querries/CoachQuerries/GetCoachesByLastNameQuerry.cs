using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.CoachQuerries
{
    public class GetCoachesByLastNameQuerry : IRequest<List<CoachDto>>
    {
        public string LastName { get; set; }
        public GetCoachesByLastNameQuerry(string lastName)
        {
            LastName = lastName;
        }
    }
}
