using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.AthleteCommands
{
    public class CreateAthleteCommand : IRequest<bool>
    {
        public AthleteDto AthleteDto { get; set; }
        public int CountryId { get; set; }
        public int CoachId { get; set; }
        public CreateAthleteCommand(AthleteDto athleteDto, int countryId, int coachId)
        {
            AthleteDto = athleteDto;
            CountryId = countryId;
            CoachId = coachId;
        }
    }
}
