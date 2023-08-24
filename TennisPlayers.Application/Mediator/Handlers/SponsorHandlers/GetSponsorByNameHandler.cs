using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.SponsorQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.SponsorHandlers
{
    public class GetSponsorByNameHandler : IRequestHandler<GetSponsorByNameQuerry, SponsorDto>
    {
        private readonly ISponsorService _sponsorService;
        public GetSponsorByNameHandler(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }
        public async Task<SponsorDto> Handle(GetSponsorByNameQuerry request, CancellationToken cancellationToken)
        {
            return _sponsorService.GetSponsorByName(request.Name);
        }
    }
}
