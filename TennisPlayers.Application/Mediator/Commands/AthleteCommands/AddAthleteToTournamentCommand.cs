using MediatR;

namespace TennisPlayers.Application.Mediator.Commands.AthleteCommands
{
    public class AddAthleteToTournamentService : IRequest<bool>
    {
        public int AthleteId { get; set; }
        public int TournamentId { get; set; }
        public AddAthleteToTournamentService(int athleteId, int tournamentId)
        {
            AthleteId = athleteId;
            TournamentId = tournamentId;
        }
    }
}
