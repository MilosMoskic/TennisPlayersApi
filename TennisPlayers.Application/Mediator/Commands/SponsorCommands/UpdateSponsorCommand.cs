using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.SponsorCommands
{
    public class UpdateSponsorCommand : IRequest<bool>
    {
        public int SponsorId { get; set; }
        public SponsorDto SponsorDto { get; set; }
        public UpdateSponsorCommand(SponsorDto sponsorDto, int sponsorId)
        {
            SponsorId = sponsorId;
            SponsorDto = sponsorDto;
        }
    }
}
