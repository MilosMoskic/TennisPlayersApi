using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.CoachCommands;

namespace TennisPlayers.Application.Mediator.Handlers.CoachHandlers
{
    public class UpdateCoachHandler : IRequestHandler<UpdateCoachCommand, bool>
    {
        private readonly ICoachService _coachService;
        public UpdateCoachHandler(ICoachService coachService)
        {
            _coachService = coachService;
        }
        public async Task<bool> Handle(UpdateCoachCommand request, CancellationToken cancellationToken)
        {
            if (!_coachService.CoachExists(request.CoachId))
                return false;

            return _coachService.UpdateCoach(request.CoachId, request.CoachDto);
        }
    }
}
