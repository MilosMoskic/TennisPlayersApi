using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface IAthleteService
    {
        Task<List<AthleteDto>> GetAllAthletes();
        AthleteDto GetAthleteById(int id);
        AthleteDto GetAthleteByName(string name);
        AthleteDto GetAthleteByRanking(int ranking);
        Task<List<AthleteDto>> GetAthletesBySponsor(int sponsorId);
        decimal GetAthleteWinPercent(string name);
        Task<AthleteDto> GetAthleteByAthleteIdAsNoTracking(int athleteId);
        bool AthleteExists(int id);
        bool AthleteExists(string name);
        bool AddAthlete(int coachId, int countryId, AthleteDto athlete);
        bool UpdateAthlete(int athleteId, AthleteDto athleteDto);
        bool RemoveAthleteFromSponsor(int athleteId, int sponsorId);
        bool DeleteAthlete(AthleteDto athleteDto);
    }
}
