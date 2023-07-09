namespace TennisPlayers.Domain.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurfaceType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Location Location { get; set; }
        public List<AthleteTournament> AthleteTournaments { get; set; }
    }
}
