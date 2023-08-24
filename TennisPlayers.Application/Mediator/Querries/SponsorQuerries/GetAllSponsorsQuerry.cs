using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.SponsorQuerries
{
    public class GetAllSponsorsQuerry : IRequest<List<SponsorDto>>
    {
    }
}
