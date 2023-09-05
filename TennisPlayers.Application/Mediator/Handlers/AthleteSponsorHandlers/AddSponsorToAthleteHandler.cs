using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.AthleteSponsorCommands;

namespace TennisPlayers.Application.Mediator.Handlers.AthleteSponsorHandlers
{
    public class AddSponsorToAthleteHandler : IRequestHandler<AddSponsorToAthleteCommand, bool>
    {
        private readonly IAthleteService _athleteService;
        private readonly ISponsorService _sponsorService;
        private readonly IAthleteSponsorService _athleteSponsorService;
        public AddSponsorToAthleteHandler(IAthleteService athleteService,ISponsorService sponsorService, IAthleteSponsorService athleteSponsorService)
        {
            _sponsorService = sponsorService;
            _athleteService = athleteService;
            _athleteSponsorService = athleteSponsorService;
        }
        public async Task<bool> Handle(AddSponsorToAthleteCommand request, CancellationToken cancellationToken)
        {
            if (!_athleteService.AthleteExists(request.AthleteId))
                return false;

            if (!_sponsorService.SponsorExists(request.SponsorId))
                return false;

            return _athleteSponsorService.AddSponsorToAthlete(request.AthleteId, request.SponsorId, request.AthleteSponsorDto);
        }
    }
}
