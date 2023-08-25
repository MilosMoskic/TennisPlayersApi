using MediatR;

namespace TennisPlayers.Application.Mediator.Commands.LocationCommands
{
    public class DeleteLocationCommand : IRequest<bool>
    {
        public int LocationId { get; set; }
        public DeleteLocationCommand(int locationId)
        {
            LocationId = locationId;
        }
    }
}
