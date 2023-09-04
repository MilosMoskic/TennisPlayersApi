using TennisPlayers.Domain.Models;

namespace TennisPlayers.Domain.Interfaces
{
    public interface IAthleteRepository
    {
        Task<List<Athlete>> GetAllAthletes();
        Task<Athlete> GetAthleteAsync(int id);
        Athlete GetAthlete(int id);
        Athlete GetAthlete(string lastName);
        Athlete GetAthleteByRanking(int ranking);
        decimal GetAthleteWinPercent(string name);
        ICollection<Athlete> GetAthletesBySponsor(int sponsorId);
        Task<Athlete> GetAthleteByAthleteIdAsNoTracking(int athleteId);
        bool AthleteExists(int id);
        bool AthleteExists(string name);
        bool AddAthlete(Coach coach, Country country, Athlete athlete);
        bool UpdateAthlete(Athlete athlete);
        bool DeleteAthlete(Athlete athlete);
        bool RemoveAthleteFromSponsor(int athleteId, int sponsorId);
        bool Save();
    }
}
