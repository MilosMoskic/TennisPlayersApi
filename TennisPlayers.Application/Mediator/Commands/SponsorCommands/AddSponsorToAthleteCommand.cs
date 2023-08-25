using MediatR;

namespace TennisPlayers.Application.Mediator.Commands.SponsorCommands
{
    public class AddSponsorToAthleteCommand : IRequest<bool>
    {
        public int AthleteId { get; set; }
        public int SponsorId { get; set; }
        public AddSponsorToAthleteCommand(int athleteId, int sponsorId)
        {
            AthleteId = athleteId;
            SponsorId = sponsorId;
        }
    }
}
