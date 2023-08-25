using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.CoachCommands
{
    public class UpdateCoachCommand : IRequest<bool>
    {
        public CoachDto CoachDto { get; set; }
        public int CoachId { get; set; }
        public UpdateCoachCommand(CoachDto coachDto, int coachId) 
        {
            CoachDto = coachDto;
            CoachId = coachId;
        }
    }
}
