using MediatR;

namespace TennisPlayers.Application.Mediator.Commands.AthleteCommands
{
    public class DeleteAthleteCommand : IRequest<bool>
    {
        public int AthleteId { get; set; }
        public DeleteAthleteCommand(int athleteId)
        {
            AthleteId = athleteId;
        }
    }
}
