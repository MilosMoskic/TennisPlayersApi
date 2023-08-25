using TennisPlayers.Application.Dto;
using TennisPlayers.Domain.Models;

namespace TennisPlayers.Application.Interfaces
{
    public interface ICoachService
    {
        public Task<List<CoachDto>> GetAllCoaches();
        public CoachDto GetCoachById(int id);
        public Task<List<CoachDto>> GetCoachesByLastName(string lastName);
        public bool CoachExists(int id);
        public bool CoachExists(string lastName);
        public bool AddCoach(CoachDto coachDto);
        public bool UpdateCoach(int coachId, CoachDto coachDto);
        public bool DeleteCoach(CoachDto coachDto);
        public Task<CoachDto> GetCoachByCoachIdAsNoTracking(int coachId);
    }
}
