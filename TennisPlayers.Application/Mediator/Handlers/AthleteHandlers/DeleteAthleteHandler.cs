using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.AthleteCommands;

namespace TennisPlayers.Application.Mediator.Commands.AthleteHandlers
{
    public class DeleteAthleteHandler : IRequestHandler<DeleteAthleteCommand, bool>
    {
        private readonly IAthleteService _athleteService;
        public DeleteAthleteHandler(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }
        public async Task<bool> Handle(DeleteAthleteCommand request, CancellationToken cancellationToken)
        {
            if (!_athleteService.AthleteExists(request.AthleteId))
                return false;

            var athleteToDelete = await _athleteService.GetAthleteByAthleteIdAsNoTracking(request.AthleteId);

            return _athleteService.DeleteAthlete(athleteToDelete);
        }
    }
}
