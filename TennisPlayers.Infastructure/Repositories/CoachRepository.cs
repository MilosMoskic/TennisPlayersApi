﻿using Microsoft.EntityFrameworkCore;
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

        public bool AddCoach(Coach coach)
        {
            _context.Coaches.Add(coach);
            return Save();
        }

        public bool CoachExists(int id)
        {
            return _context.Coaches.Any(c => c.Id == id);
        }

        public bool CoachExists(string lastName)
        {
            return _context.Coaches.Any(c => c.LastName== lastName);
        }

        public bool DeleteCoach(Coach coach)
        {
            _context.Remove(coach);
            return Save();
        }

        public Task<List<Coach>> GetAllCoaches()
        {
            return _context.Coaches.ToListAsync();
        }

        public Coach GetCoach(int id)
        {
            return _context.Coaches.Where(c => c.Id == id).FirstOrDefault();
        }

        public List<Coach> GetCoach(string lastName)
        {
            return _context.Coaches.Where(c => c.LastName == lastName).ToList();
        }

        public async Task<Coach> GetCoachByCoachIdAsNoTracking(int coachId)
        {
            return await _context.Coaches.Where(c => c.Id == coachId).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCoach(Coach coach)
        {
            _context.Update(coach);
            return Save();
        }
    }
}
