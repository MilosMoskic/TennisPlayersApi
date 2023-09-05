using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.CoachCommands
{
    public class CreateCoachCommand : IRequest<bool>
    {
        public CoachDto CoachDto { get; set; }
        public CreateCoachCommand(CoachDto coachDto)
        {
            CoachDto = coachDto;
        }
    }
}
