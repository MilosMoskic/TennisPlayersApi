namespace TennisPlayers.Domain.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public List<Tournament> Tournaments { get; set; }
    }
}
