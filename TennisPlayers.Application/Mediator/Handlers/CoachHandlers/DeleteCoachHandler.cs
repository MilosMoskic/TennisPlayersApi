using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.CoachCommands;

namespace TennisPlayers.Application.Mediator.Handlers.CoachHandlers
{
    public class DeleteCoachHandler : IRequestHandler<DeleteCoachCommand, bool>
    {
        private readonly ICoachService _coachService;
        public DeleteCoachHandler(ICoachService coachService)
        {
            _coachService = coachService;
        }

        public async Task<bool> Handle(DeleteCoachCommand request, CancellationToken cancellationToken)
        {
            if (!_coachService.CoachExists(request.CoachId))
                return false;

            var coachToDelete = await _coachService.GetCoachByCoachIdAsNoTracking(request.CoachId);

            return _coachService.DeleteCoach(coachToDelete);
        }
    }
}
