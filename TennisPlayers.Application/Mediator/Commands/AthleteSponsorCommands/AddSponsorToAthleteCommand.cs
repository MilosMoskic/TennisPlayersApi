using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.AthleteSponsorCommands
{
    public class AddSponsorToAthleteCommand : IRequest<bool>
    {
        public int SponsorId { get; set; }
        public int AthleteId { get; set; }
        public AthleteSponsorDto AthleteSponsorDto { get; set; }
        public AddSponsorToAthleteCommand(int sponsorId, int athleteId, AthleteSponsorDto athleteSponsorDto)
        {
            SponsorId = sponsorId;
            AthleteId = athleteId;
            AthleteSponsorDto = athleteSponsorDto;
        }
    }
}
