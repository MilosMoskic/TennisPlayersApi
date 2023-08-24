using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.SponsorQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.SponsorHandlers
{
    public class GetSponsorByIdHandler : IRequestHandler<GetSponsorByIdQuerry, SponsorDto>
    {
        private readonly ISponsorService _sponsorService;
        public GetSponsorByIdHandler(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        public async Task<SponsorDto> Handle(GetSponsorByIdQuerry request, CancellationToken cancellationToken)
        {
            return _sponsorService.GetSponsorById(request.SponsorId);
        }
    }
}
