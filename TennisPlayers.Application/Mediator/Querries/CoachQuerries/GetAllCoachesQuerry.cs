using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.CoachQuerries
{
    public class GetAllCoachesQuerry : IRequest<List<CoachDto>>
    {
    }
}
