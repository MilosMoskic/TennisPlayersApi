using MediatR;

namespace TennisPlayers.Application.Mediator.Commands.AthleteCommands
{
    public class RemoveAthleteFromSponsorCommand : IRequest<bool>
    {
        public int AthleteId { get; set; }
        public int SponsorId { get; set; }
        public RemoveAthleteFromSponsorCommand(int athleteId, int sponsorId)
        {
            AthleteId = athleteId;
            SponsorId = sponsorId;
        }
    }
}
