using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.AthleteTournamentCommands
{
    public class AddAthleteToTournamentCommand : IRequest<bool>
    {
        public int AthleteId { get; set; }
        public int TournamentId { get; set; }
        public AthleteTournamentDto AthleteTournamentDto { get; set; }
        public AddAthleteToTournamentCommand(int athleteId, int tournamentId, AthleteTournamentDto athleteTournamentDto)
        {
            AthleteId = athleteId;
            TournamentId = tournamentId;
            AthleteTournamentDto = athleteTournamentDto;
        }
    }
}
