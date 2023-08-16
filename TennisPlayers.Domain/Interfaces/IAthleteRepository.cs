using TennisPlayers.Domain.Models;

namespace TennisPlayers.Domain.Interfaces
{
    public interface IAthleteRepository
    {
        Task<List<Athlete>> GetAllAthletes();
        Athlete GetAthlete(int id);
        Athlete GetAthlete(string lastName);
        Athlete GetAthleteByRanking(int ranking);
        public decimal GetAthleteWinPercent(string name);
        ICollection<Athlete> GetAthletesByTournament(int tournamentId);
        ICollection<Athlete> GetAthletesBySponsor(int sponsorId);
        bool AthleteExists(int id);
        bool AthleteExists(string name);
        bool AddAthlete(Coach coach, Country country, Athlete athlete);
        bool Save();
    }
}
