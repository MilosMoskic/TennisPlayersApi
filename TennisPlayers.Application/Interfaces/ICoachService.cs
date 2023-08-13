using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface ICoachService
    {
        public Task<List<CoachDto>> GetAllCoaches();
        public CoachDto GetCoachById(int id);
        public bool CoachExists(int id);
    }
}
