using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.LocationCommands
{
    public class UpdateLocationCommand : IRequest<bool>
    {
        public LocationDto LocationDto { get; set; }
        public int LocationId { get; set; }
        public UpdateLocationCommand(LocationDto locationDto, int locationId)
        {
            LocationDto = locationDto;
            LocationId = locationId;
        }
    }
}
