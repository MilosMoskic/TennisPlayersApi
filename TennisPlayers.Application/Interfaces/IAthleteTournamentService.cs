using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface IAthleteTournamentService
    {
        bool AddAthleteToTournament(int athleteId, int tournamentId, AthleteTournamentDto athleteTournamentDto);
        Task<List<AthleteDto>> GetAthletesByTournament(int tournamentId);
        bool RemoveAthleteFromTournament(int athleteId, int tournamentId);
    }
}