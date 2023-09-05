using TennisPlayers.Application.Dto;
using TennisPlayers.Domain.Models;

namespace TennisPlayers.Application.Interfaces
{
    public interface ICoachService
    {
        Task<List<CoachDto>> GetAllCoaches();
        CoachDto GetCoachById(int id);
        Task<List<CoachDto>> GetCoachesByLastName(string lastName);
        bool CoachExists(int id);
        bool CoachExists(string lastName);
        bool AddCoach(CoachDto coachDto);
        bool UpdateCoach(int coachId, CoachDto coachDto);
        bool DeleteCoach(CoachDto coachDto);
        Task<CoachDto> GetCoachByCoachIdAsNoTracking(int coachId);
    }
}
