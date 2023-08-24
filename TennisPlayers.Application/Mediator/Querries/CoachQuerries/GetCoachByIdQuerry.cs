using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.CoachQuerries
{
    public class GetCoachByIdQuerry : IRequest<CoachDto>
    {
        public int CoachId { get; set; }
        public GetCoachByIdQuerry(int coachId)
        {
            CoachId = coachId;
        }
    }
}
