using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface IAthleteService
    {
        public Task<List<AthleteDto>> GetAllAthletes();
        public AthleteDto GetAthleteById(int id);
        public AthleteDto GetAthleteByName(string name);
        public AthleteDto GetAthleteByRanking(int ranking);
        public Task<List<AthleteDto>> GetAthletesBySponsor(int sponsorId);
        public decimal GetAthleteWinPercent(string name);
        public Task<AthleteDto> GetAthleteByAthleteIdAsNoTracking(int athleteId);
        public bool AthleteExists(int id);
        public bool AthleteExists(string name);
        public bool AddAthlete(int coachId, int countryId, AthleteDto athlete);
        public bool UpdateAthlete(int athleteId, AthleteDto athleteDto);
        public bool RemoveAthleteFromSponsor(int athleteId, int sponsorId);
        public bool DeleteAthlete(AthleteDto athleteDto);
    }
}
