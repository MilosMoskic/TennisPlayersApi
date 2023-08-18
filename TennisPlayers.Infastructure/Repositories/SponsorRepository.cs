using Microsoft.EntityFrameworkCore;
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

        public bool AddSponsor(Sponsor sponsor)
        {
            _context.Sponsors.Add(sponsor);
            return Save();
        }

        public bool AddSponsorToAthlete(Athlete athlete, Sponsor sponsor)
        {
            var athleteSponsors = new AthleteSponsor()
            {
                Athlete = athlete,
                Sponsor = sponsor,
            };

            _context.AthleteSponsors.Add(athleteSponsors);
            return Save();
        }

        public bool DeleteSponsor(Sponsor sponsor)
        {
            _context.Remove(sponsor);
            return Save();
        }

        public Task<List<Sponsor>> GetAllSponsorsByNW(decimal netWorth)
        {
            return _context.Sponsors.Where(s => s.NetWorth >= netWorth).ToListAsync();
        }

        public Sponsor GetSponsor(int id)
        {
            return _context.Sponsors.Where(s => s.Id == id).AsNoTracking().FirstOrDefault();
        }

        public Sponsor GetSponsor(string name)
        {
            return _context.Sponsors.Where(s => s.Name == name).FirstOrDefault();
        }

        public Task<List<Sponsor>> GetSponsors()
        {
            return _context.Sponsors.ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool SponsorExists(int id)
        {
            return _context.Sponsors.Any(s => s.Id == id);
        }

        public bool SponsorExists(string sponsor)
        {
            return _context.Sponsors.Any(s => s.Name == sponsor);
        }

        public bool UpdateSponsor(Sponsor sponsor)
        {
            _context.Update(sponsor);
            return Save();
        }
    }
}
