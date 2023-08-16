using TennisPlayers.Domain.Models;

namespace TennisPlayers.Domain.Interfaces
{
    public interface ICoachRepository
    {
        Task<List<Coach>> GetAllCoaches();
        Coach GetCoach(int id);
        List<Coach> GetCoach(string lastName);
        bool CoachExists(int id);
        bool CoachExists(string lastName);
    }
}
