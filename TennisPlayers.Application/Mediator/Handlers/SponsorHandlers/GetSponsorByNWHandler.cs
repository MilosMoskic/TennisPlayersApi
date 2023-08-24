using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.SponsorQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.SponsorHandlers
{
    public class GetSponsorByNWHandler : IRequestHandler<GetSponsorsByNWQuerry, List<SponsorDto>>
    {
        private readonly ISponsorService _sponsorService;
        public GetSponsorByNWHandler(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }
        public Task<List<SponsorDto>> Handle(GetSponsorsByNWQuerry request, CancellationToken cancellationToken)
        {
            return _sponsorService.GetSponsorsByNW(request.NetWorth);
        }
    }
}
