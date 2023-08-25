using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.SponsorCommands;

namespace TennisPlayers.Application.Mediator.Handlers.SponsorHandlers
{
    public class UpdateSponsorHandler : IRequestHandler<UpdateSponsorCommand, bool>
    {
        private readonly ISponsorService _sponsorService;
        public UpdateSponsorHandler(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        public async Task<bool> Handle(UpdateSponsorCommand request, CancellationToken cancellationToken)
        {
            if (!_sponsorService.SponsorExists(request.SponsorId))
                return false;

            return _sponsorService.UpdateSponsor(request.SponsorId, request.SponsorDto);
        }
    }
}
