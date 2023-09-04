using TennisPlayers.Domain.Models;
using TennisPlayers.Infastructure.Context;

namespace TennisPlayers.Infastructure.Repositories
{
    public class AthleteSponsorRepository : IAthleteSponsorRepository
    {
        private readonly TennisPlayersContext _context;
        public AthleteSponsorRepository(TennisPlayersContext context)
        {
            _context = context; 
        }
        public ICollection<Athlete> GetAthletesBySponsor(int sponsorId)
        {
            return _context.AthleteSponsors.Where(a => a.SponsorId == sponsorId).Select(a => a.Athlete).ToList();
        }
        public ICollection<Sponsor> GetSponsorsOfAthlete(int athleteId)
        {
            return _context.AthleteSponsors.Where(a => a.AthleteId == athleteId).Select(a => a.Sponsor).ToList();
        }
        public bool AddSponsorToAthlete(AthleteSponsor athleteSponsor)
        {

            _context.AthleteSponsors.Add(athleteSponsor);
            return Save();
        }

        public bool RemoveSponsorFromAthlete(int athleteId, int sponsorId)
        {
            var athleteSponsor = _context.AthleteSponsors
                .Where(a => a.AthleteId == athleteId)
                .Where(t => t.SponsorId == sponsorId).FirstOrDefault();

            _context.AthleteSponsors.Remove(athleteSponsor);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
