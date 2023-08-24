using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.AthleteQuerries
{
    public class GetAthleteByIdQuerry : IRequest<AthleteDto>
    {
        public int AthleteId { get; set; }
        public GetAthleteByIdQuerry(int athleteId)
        {
            AthleteId = athleteId;
        }
    }
}
