namespace TennisPlayers.Domain.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Ranking { get; set; }
        public int TotalWins { get; set; }
        public int TotalLoses { get; set; }
        public string Status { get; set; }
        public Country Country { get; set; }
        public Coach Coach { get; set; }
        public List<AthleteSponsor> AthleteSponsors { get; set; }
        public List<AthleteTournament> AthleteTournaments { get; set; }
    }
}
