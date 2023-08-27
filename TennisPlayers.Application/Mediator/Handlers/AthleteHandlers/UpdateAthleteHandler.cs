using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.AthleteCommands;
using TennisPlayers.Application.Services;

namespace TennisPlayers.Application.Mediator.Commands.AthleteHandlers
{
    public class UpdateAthleteHandler : IRequestHandler<UpdateAthleteCommand, bool>
    {
        private readonly IAthleteService _athleteService;
        public UpdateAthleteHandler(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }

        public async Task<bool> Handle(UpdateAthleteCommand request, CancellationToken cancellationToken)
        {
            if (!_athleteService.AthleteExists(request.AthleteId))
                return false;

            return _athleteService.UpdateAthlete(request.AthleteId, request.AthleteDto);
        }
    }
}
