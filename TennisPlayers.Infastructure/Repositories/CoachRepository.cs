using Microsoft.EntityFrameworkCore;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;
using TennisPlayers.Infastructure.Context;

namespace TennisPlayers.Infastructure.Repositories
{
    public class CoachRepository : ICoachRepository
    {
        private readonly TennisPlayersContext _context;

        public CoachRepository(TennisPlayersContext context)
        {
            _context = context;
        }

        public bool CoachExists(int id)
        {
            return _context.Coaches.Any(c => c.Id == id);
        }

        public Task<List<Coach>> GetAllCoaches()
        {
            return _context.Coaches.ToListAsync();
        }

        public Coach GetCoach(int id)
        {
            return _context.Coaches.Where(c => c.Id == id).FirstOrDefault();
        }

        public Coach GetCoach(string lastName)
        {
            return _context.Coaches.Where(c => c.LastName == lastName).FirstOrDefault();
        }
    }
}
