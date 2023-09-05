using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.SponsorQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.SponsorHandlers
{
    public class GetAllSponsorsHandler : IRequestHandler<GetAllSponsorsQuerry, List<SponsorDto>>
    {
        private readonly ISponsorService _sponsorService;
        public GetAllSponsorsHandler(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }
        public Task<List<SponsorDto>> Handle(GetAllSponsorsQuerry request, CancellationToken cancellationToken)
        {
            return _sponsorService.GetAllSponsors();
        }
    }
}
