using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.AthleteSponsorCommands;

namespace TennisPlayers.Application.Mediator.Handlers.AthleteSponsorHandlers
{
    public class RemoveSponsorFromAthleteHandler : IRequestHandler<RemoveSponsorFromAthleteCommand, bool>
    {
        private readonly ISponsorService _sponsorService;
        private readonly IAthleteService _athleteService;
        private readonly IAthleteSponsorService _athleteSponsorService;
        public RemoveSponsorFromAthleteHandler(IAthleteService athleteService,ISponsorService sponsorService, IAthleteSponsorService athleteSponsorService)
        {
            _athleteService = athleteService;
            _sponsorService = sponsorService;
            _athleteSponsorService = athleteSponsorService;
        }

        public async Task<bool> Handle(RemoveSponsorFromAthleteCommand request, CancellationToken cancellationToken)
        {
            if (!_athleteService.AthleteExists(request.AthleteId))
                return false;

            if (!_sponsorService.SponsorExists(request.SponsorId))
                return false;

            return _athleteSponsorService.RemoveSponsorFromAthlete(request.AthleteId, request.SponsorId);
        }
    }
}
