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
        public Athlete GetAthlete(int id)
        {
            return _context.Athletes.Where(a => a.Id == id).FirstOrDefault();
        }

        public Athlete GetAthlete(string lastName)
        {
            return _context.Athletes.Where(a => a.LastName == lastName).FirstOrDefault();
        }

        public Athlete GetAthleteByRanking(int ranking)
        {
            return _context.Athletes.Where(a => a.Ranking == ranking).FirstOrDefault();
        }
        public ICollection<Athlete> GetAthletesByTournament(int tournamentId)
        {
            return _context.AthleteTournaments.Where(a => a.TournamentId == tournamentId).Select(a => a.Athlete).ToList();
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
        public bool AddAthleteToTournament(Athlete athlete, Tournament tournament)
        {
            var athleteTournament = new AthleteTournament()
            {
                Athlete = athlete,
                Tournament = tournament,
            };

            _context.AthleteTournaments.Add(athleteTournament);
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
    }
}
