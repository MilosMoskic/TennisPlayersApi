using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.SponsorCommands;

namespace TennisPlayers.Application.Mediator.Handlers.SponsorHandlers
{
    public class DeleteSponsorHandler : IRequestHandler<DeleteSponsorCommand, bool>
    {
        public readonly ISponsorService _sponsorService;
        public DeleteSponsorHandler(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        public async Task<bool> Handle(DeleteSponsorCommand request, CancellationToken cancellationToken)
        {
            if (!_sponsorService.SponsorExists(request.SponsorId))
                return false;

            var sponsorToDelete = await _sponsorService.GetSponsorBySponsorIdAsNoTracking(request.SponsorId);

            return _sponsorService.DeleteSponsor(sponsorToDelete);
        }
    }
}
