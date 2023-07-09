namespace TennisPlayers.Domain.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Athlete> Athletes { get; set; }
    }
}
