using Microsoft.EntityFrameworkCore;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;
using TennisPlayers.Infastructure.Context;

namespace TennisPlayers.Infastructure.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly TennisPlayersContext _context;

        public TournamentRepository(TennisPlayersContext context)
        {
            _context = context;
        }

        public bool AddTournament(Location location, Tournament tournament)
        {
            tournament.Location = location;
            _context.Tournaments.Add(tournament);
            return Save();
        }

        public bool DeleteTournament(Tournament tournament)
        {
            _context.Remove(tournament);
            return Save();
        }

        public async Task<Tournament> GetTournamentAsync(int id)
        {
            return await _context.Tournaments.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<Tournament> GetTournamentByTournamentIdAsNoTracking(int tournamentId)
        {
            return await _context.Tournaments.AsNoTracking().FirstOrDefaultAsync(a => a.Id == tournamentId);
        }

        public Tournament GetTournament(string name)
        {
            return _context.Tournaments.Where(t => t.Name == name).FirstOrDefault();
        }

        public Task<List<Tournament>> GetTournaments()
        {
            return _context.Tournaments.ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TournamentExists(int id)
        {
            return _context.Tournaments.Any(t => t.Id == id);
        }

        public bool TournamentExists(string name)
        {
            return _context.Tournaments.Any(t => t.Name == name);
        }

        public bool UpdateTournament(Tournament tournament)
        {
            _context.Update(tournament);
            return Save();
        }
    }
}
