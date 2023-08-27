using TennisPlayers.Domain.Models;

namespace TennisPlayers.Infastructure.Repositories
{
    public interface IAthleteTournamentRepository
    {
        public bool AddAthleteToTournament(AthleteTournament athleteTournament);
        ICollection<Athlete> GetAthletesByTournament(int tournamentId);
        bool RemoveAthleteFromTournament(int athleteId, int tournamentId);
        bool Save();
    }
}