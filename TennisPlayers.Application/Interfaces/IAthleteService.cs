using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface IAthleteService
    {
        public Task<List<AthleteDto>> GetAllAthletes();
        public AthleteDto GetAthleteById(int id);
        public AthleteDto GetAthleteByName(string name);
        public AthleteDto GetAthleteByRanking(int ranking);
        public Task<List<AthleteDto>> GetAthletesByTournament(int tournamentId);
        public Task<List<AthleteDto>> GetAthletesBySponsor(int sponsorId);
        public decimal GetAthleteWinPercent(string name);
        public bool AthleteExists(int id);
        public bool AthleteExists(string name);
    }
}
