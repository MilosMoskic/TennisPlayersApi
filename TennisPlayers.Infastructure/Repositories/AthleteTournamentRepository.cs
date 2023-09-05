using TennisPlayers.Domain.Models;
using TennisPlayers.Infastructure.Context;

namespace TennisPlayers.Infastructure.Repositories
{
    public class AthleteTournamentRepository : IAthleteTournamentRepository
    {
        private readonly TennisPlayersContext _context;
        public AthleteTournamentRepository(TennisPlayersContext context)
        {
            _context = context;
        }
        public ICollection<Athlete> GetAthletesByTournament(int tournamentId)
        {
            return _context.AthleteTournaments.Where(a => a.TournamentId == tournamentId).Select(a => a.Athlete).ToList();
        }
        public bool AddAthleteToTournament(AthleteTournament athleteTournament)
        {

            _context.AthleteTournaments.Add(athleteTournament);
            return Save();
        }

        public bool RemoveAthleteFromTournament(int athleteId, int tournamentId)
        {
            var athleteTournament = _context.AthleteTournaments
                .Where(a => a.AthleteId == athleteId)
                .Where(t => t.TournamentId == tournamentId).FirstOrDefault();

            _context.AthleteTournaments.Remove(athleteTournament);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
