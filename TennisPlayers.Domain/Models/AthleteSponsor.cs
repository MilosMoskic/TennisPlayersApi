namespace TennisPlayers.Domain.Models
{
    public class AthleteSponsor
    {
        public int AthleteId { get; set; }
        public int SponsorId { get; set; }
        public Athlete Athlete { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}
