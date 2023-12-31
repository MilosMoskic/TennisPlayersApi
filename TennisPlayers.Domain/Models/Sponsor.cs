﻿namespace TennisPlayers.Domain.Models
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal NetWorth { get; set; }
        public List<AthleteSponsor> AthleteSponsors { get; set; }
    }
}
