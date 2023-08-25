using MediatR;

namespace TennisPlayers.Application.Mediator.Commands.CoachCommands
{
    public class DeleteCoachCommand : IRequest<bool>
    {
        public int CoachId { get; set; }
        public DeleteCoachCommand(int coachId)
        {
            CoachId = coachId;
        }
    }
}
