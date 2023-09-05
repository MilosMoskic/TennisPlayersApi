using MediatR;

namespace TennisPlayers.Application.Mediator.Commands.SponsorCommands
{
    public class DeleteSponsorCommand : IRequest<bool>
    {
        public int SponsorId { get; set; }
        public DeleteSponsorCommand(int sponsorId)
        {
            SponsorId = sponsorId;
        }
    }
}
