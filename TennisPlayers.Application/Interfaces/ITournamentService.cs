using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface ITournamentService
    {
        public Task<List<TournamentDto>> GetAllTournaments();
        public TournamentDto GetTournamentById(int id);
        public TournamentDto GetTournamentByName(string name);
        public bool TournamentExists(int id);
        public bool TournamentExists(string name);
        public bool AddTournament(int locationId, TournamentDto tournament);
        public bool UpdateTournament(int tournamentId, TournamentDto tournamentDto);
    }
}
