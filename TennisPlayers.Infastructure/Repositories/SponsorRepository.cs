﻿using Microsoft.EntityFrameworkCore;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;
using TennisPlayers.Infastructure.Context;

namespace TennisPlayers.Infastructure.Repositories
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly TennisPlayersContext _context;
        public SponsorRepository(TennisPlayersContext context)
        {
            _context = context;
        }

        public Task<List<Sponsor>> GetAllSponsorsByNW(decimal netWorth)
        {
            return _context.Sponsors.Where(s => s.NetWorth >= netWorth).ToListAsync();
        }

        public Sponsor GetSponsor(int id)
        {
            return _context.Sponsors.Where(s => s.Id == id).FirstOrDefault();
        }

        public Sponsor GetSponsor(string name)
        {
            return _context.Sponsors.Where(s => s.Name == name).FirstOrDefault();
        }

        public Task<List<Sponsor>> GetSponsors()
        {
            return _context.Sponsors.ToListAsync();
        }

        public bool SponsorExists(int id)
        {
            return _context.Sponsors.Any(s => s.Id == id);
        }

        public bool SponsorExists(string sponsor)
        {
            return _context.Sponsors.Any(s => s.Name == sponsor);
        }
    }
}