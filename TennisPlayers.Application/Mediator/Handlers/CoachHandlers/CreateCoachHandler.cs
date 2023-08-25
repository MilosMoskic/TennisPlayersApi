using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.CoachCommands;

namespace TennisPlayers.Application.Mediator.Handlers.CoachHandlers
{
    public class CreateCoachHandler : IRequestHandler<CreateCoachCommand, bool>
    {
        private readonly ICoachService _coachService;
        public CreateCoachHandler(ICoachService coachService)
        {
            _coachService = coachService;
        }
        public async Task<bool> Handle(CreateCoachCommand request, CancellationToken cancellationToken)
        {
            return _coachService.AddCoach(request.CoachDto);
        }
    }
}
