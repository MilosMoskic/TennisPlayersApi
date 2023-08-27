using Microsoft.EntityFrameworkCore;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;
using TennisPlayers.Infastructure.Context;

namespace TennisPlayers.Infastructure.Repositories
{
    public class AthleteRepository : IAthleteRepository
    {
        private readonly TennisPlayersContext _context;

        public AthleteRepository(TennisPlayersContext context)
        {
            _context = context;
        }
        public async Task<Athlete> GetAthleteAsync(int id)
        {
            return await _context.Athletes.FirstOrDefaultAsync(a => a.Id == id);
        }

        public Athlete GetAthlete(string lastName)
        {
            return _context.Athletes.Where(a => a.LastName == lastName).FirstOrDefault();
        }

        public async Task<Athlete> GetAthleteByAthleteIdAsNoTracking(int athleteId)
        {
            return await _context.Athletes.AsNoTracking().FirstOrDefaultAsync(a => a.Id == athleteId);
        }

        public Athlete GetAthleteByRanking(int ranking)
        {
            return _context.Athletes.Where(a => a.Ranking == ranking).FirstOrDefault();
        }

        public Task<List<Athlete>> GetAllAthletes()
        {
            return _context.Athletes.ToListAsync();
        }

        public decimal GetAthleteWinPercent(string name)
        {
            var athlete = _context.Athletes.Where(a => a.LastName == name).FirstOrDefault();
            decimal wins = Convert.ToDecimal(athlete.TotalWins);
            decimal loses = Convert.ToDecimal(athlete.TotalLoses);
            decimal winPercent = (wins / (wins + loses)) * 100;
            return winPercent;
        }

        public bool AthleteExists(int id)
        {
            return _context.Athletes.Any(a => a.Id == id);
        }

        public bool AthleteExists(string name)
        {
            return _context.Athletes.Any(a => a.LastName == name);
        }

        public ICollection<Athlete> GetAthletesBySponsor(int sponsorId)
        {
            return _context.AthleteSponsors.Where(a => a.SponsorId == sponsorId).Select(a => a.Athlete).ToList();
        }

        public bool AddAthlete(Coach coach, Country country, Athlete athlete)
        {
            athlete.Coach = coach;
            athlete.Country = country;
            _context.Athletes.Add(athlete);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAthlete(Athlete athlete)
        {
            _context.Update(athlete);
            return Save();
        }

        public bool DeleteAthlete(Athlete athlete)
        {
            _context.Remove(athlete);
            return Save();
        }

        public bool RemoveAthleteFromSponsor(int athleteId, int sponsorId)
        {
            var athleteTournament = _context.AthleteSponsors
                .Where(a => a.AthleteId == athleteId)
                .Where(t => t.SponsorId == sponsorId).FirstOrDefault();

            _context.AthleteSponsors.Remove(athleteTournament);
            return Save();
        }
    }
}
