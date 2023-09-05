using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.AthleteCommands;

namespace TennisPlayers.Application.Mediator.Commands.AthleteHandlers
{
    public class CreateAthleteHandler : IRequestHandler<CreateAthleteCommand, bool>
    {
        private readonly IAthleteService _athleteService;
        private readonly ICountryService _countryService;
        private readonly ICoachService _coachService;
        public CreateAthleteHandler(IAthleteService athleteService, ICountryService countryService, ICoachService coachService)
        {
            _athleteService = athleteService;
            _countryService = countryService;
            _coachService = coachService;
        }

        public async Task<bool> Handle(CreateAthleteCommand request, CancellationToken cancellationToken)
        {
            if (!_countryService.CountryExists(request.CountryId))
                return false;

            if (!_coachService.CoachExists(request.CoachId))
                return false;

            return _athleteService.AddAthlete(request.CoachId, request.CountryId, request.AthleteDto);
        }
    }
}
