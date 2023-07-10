using TennisPlayers.Domain.Models;

namespace TennisPlayers.Domain.Interfaces
{
    public interface IAthleteRepository
    {
        ICollection<Athlete> GetAthletes();
        Athlete GetAthlete(int id);
        Athlete GetAthlete(string lastName);
        Athlete GetAthleteByRanking(int ranking);
        decimal GetAthleteWinPercent(int id);
    }
}
