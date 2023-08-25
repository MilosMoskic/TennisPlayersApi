using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.SponsorCommands;
using TennisPlayers.Domain.Models;

namespace TennisPlayers.Application.Mediator.Handlers.SponsorHandlers
{
    public class AddSponsorToAthleteHandler : IRequestHandler<AddSponsorToAthleteCommand, bool>
    {
        private readonly ISponsorService _sponsorService;
        private readonly IAthleteService _athleteService;
        public AddSponsorToAthleteHandler(ISponsorService sponsorService, IAthleteService athleteService)
        {
            _sponsorService = sponsorService;
            _athleteService = athleteService;
        }

        public async Task<bool> Handle(AddSponsorToAthleteCommand request, CancellationToken cancellationToken)
        {
            if (!_athleteService.AthleteExists(request.AthleteId))
                return false;

            if (!_sponsorService.SponsorExists(request.SponsorId))
                return false;

            return _sponsorService.AddSponsorToAthlete(request.AthleteId, request.SponsorId);
        }
    }
}
