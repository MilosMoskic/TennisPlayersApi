namespace TennisPlayers.Domain.Models
{
    public class AthleteTournament
    {
        public int AthleteId { get; set; }
        public int TournamentId { get; set; }
        public Athlete Athlete { get; set; }
        public Tournament Tournament { get; set; }
    }
}
