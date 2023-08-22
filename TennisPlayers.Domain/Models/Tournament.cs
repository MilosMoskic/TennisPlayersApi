namespace TennisPlayers.Domain.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurfaceType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Location Location { get; set; }
        public List<AthleteTournament> AthleteTournaments { get; set; }
    }
}
