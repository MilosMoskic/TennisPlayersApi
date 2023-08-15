namespace TennisPlayers.Application.Dto
{
    public class TournamentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurfaceType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
