using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.SponsorQuerries
{
    public class GetSponsorsByNWQuerry : IRequest<List<SponsorDto>>
    {
        public decimal NetWorth { get; set; }
        public GetSponsorsByNWQuerry(decimal netWorth)
        {
            NetWorth = netWorth;
        }
    }
}
