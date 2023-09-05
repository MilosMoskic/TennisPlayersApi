using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.LocationCommands
{
    public class CreateLocationCommand : IRequest<bool>
    {
        public LocationDto LocationDto { get; set; }
        public CreateLocationCommand(LocationDto locationDto)
        {
            LocationDto = locationDto;
        }
    }
}
