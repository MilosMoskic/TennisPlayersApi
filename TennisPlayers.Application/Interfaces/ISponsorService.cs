using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface ISponsorService
    {
        public Task<List<SponsorDto>> GetAllSponsors();
        public SponsorDto GetSponsorById(int id);
        public SponsorDto GetSponsorByName(string name);
        public bool SponsorExists(int id);
        public bool SponsorExists(string sponsor);
        public Task<List<SponsorDto>> GetSponsorsByNW(decimal NW);
        public bool AddSponsor(SponsorDto sponsorDto);
        public bool AddSponsorToAthlete(int athleteId, int sponsorId);
    }
}
