﻿using TennisPlayers.Domain.Models;

namespace TennisPlayers.Domain.Interfaces
{
    public interface ITournamentRepository
    {
        Task<List<Tournament>> GetTournaments();
        Task<Tournament> GetTournamentAsync(int id);
        Tournament GetTournament(string name);
        Tournament GetTournament(int id);
        Task<Tournament> GetTournamentByTournamentIdAsNoTracking(int tournamentId);
        bool TournamentExists(int id);
        bool TournamentExists(string name);
        bool AddTournament(Location location, Tournament tournament);
        bool UpdateTournament(Tournament tournament);
        bool DeleteTournament(Tournament tournament);
        bool Save();
    }
}
