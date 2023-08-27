using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.AthleteCommands
{
    public class UpdateAthleteCommand : IRequest<bool>
    {
        public int AthleteId { get; set; }
        public AthleteDto AthleteDto { get; set; }
        public UpdateAthleteCommand(AthleteDto athleteDto, int athleteId)
        {
            AthleteId = athleteId;
            AthleteDto = athleteDto;
        }
    }
}
