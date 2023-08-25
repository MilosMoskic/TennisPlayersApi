using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.SponsorCommands;

namespace TennisPlayers.Application.Mediator.Handlers.SponsorHandlers
{
    public class CreateSponsorHandler : IRequestHandler<CreateSponsorCommand, bool>
    {
        private readonly ISponsorService _sponsorService;
        public CreateSponsorHandler(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        public async Task<bool> Handle(CreateSponsorCommand request, CancellationToken cancellationToken)
        {
            return _sponsorService.AddSponsor(request.SponsorDto);
        }
    }
}
