using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.SponsorCommands
{
    public class CreateSponsorCommand : IRequest<bool>
    {
        public SponsorDto SponsorDto { get; set; }
        public CreateSponsorCommand(SponsorDto sponsorDto)
        {
            SponsorDto = sponsorDto;
        }
    }
}
