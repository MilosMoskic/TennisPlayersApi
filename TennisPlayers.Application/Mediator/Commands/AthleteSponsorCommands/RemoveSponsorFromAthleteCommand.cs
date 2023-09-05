using MediatR;

namespace TennisPlayers.Application.Mediator.Commands.AthleteSponsorCommands
{
    public class RemoveSponsorFromAthleteCommand : IRequest<bool>
    {
        public int AthleteId { get; set; }
        public int SponsorId { get; set; }
        public RemoveSponsorFromAthleteCommand(int athleteId, int sponsorId)
        {
            AthleteId = athleteId;
            SponsorId = sponsorId;
        }
    }
}
