using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.AthleteQuerries
{
    public class GetAllAthletesQuerry : IRequest<List<AthleteDto>>
    {
    }
}
