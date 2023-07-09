namespace TennisPlayers.Domain.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public List<Athlete> Athletes { get; set; }
    }
}
