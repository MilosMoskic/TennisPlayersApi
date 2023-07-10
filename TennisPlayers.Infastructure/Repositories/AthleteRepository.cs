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

        public ICollection<Athlete> GetAthletes()
        {
            return _context.Athletes.OrderBy(a => a.LastName).ToList(); 
        }

        public decimal GetAthleteWinPercent(int id)
        {
            var athlete = _context.Athletes.Where(a => a.Id == id).FirstOrDefault();

            return (athlete.TotalWins / (athlete.TotalWins + athlete.TotalLoses)) * 100;
        }
    }
}
