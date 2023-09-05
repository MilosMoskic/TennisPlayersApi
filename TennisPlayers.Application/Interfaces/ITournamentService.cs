using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface ITournamentService
    {
        Task<List<TournamentDto>> GetAllTournaments();
        TournamentDto GetTournamentById(int id);
        TournamentDto GetTournamentByName(string name);
        Task<TournamentDto> GetTournamentByTournamentIdAsNoTracking(int tournamentId);
        bool TournamentExists(int id);
        bool TournamentExists(string name);
        bool AddTournament(int locationId, TournamentDto tournament);
        bool UpdateTournament(int tournamentId, TournamentDto tournamentDto);
        bool DeleteTournament(TournamentDto tournamentDto);
    }
}
