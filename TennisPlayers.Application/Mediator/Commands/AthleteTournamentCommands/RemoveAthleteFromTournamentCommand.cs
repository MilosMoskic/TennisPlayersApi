using MediatR;

namespace TennisPlayers.Application.Mediator.Commands.AthleteTournamentCommands
{
    public class RemoveAthleteFromTournamentCommand : IRequest<bool>
    {
        public int AthleteId { get; set; }
        public int TournamentId { get; set; }
        public RemoveAthleteFromTournamentCommand(int athleteId, int tournamentId)
        {
            AthleteId = athleteId;
            TournamentId = tournamentId;
        }
    }
}
