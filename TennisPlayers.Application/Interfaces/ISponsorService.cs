using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface ISponsorService
    {
        Task<List<SponsorDto>> GetAllSponsors();
        SponsorDto GetSponsorById(int id);
        SponsorDto GetSponsorByName(string name);
        bool SponsorExists(int id);
        bool SponsorExists(string sponsor);
        Task<List<SponsorDto>> GetSponsorsByNW(decimal NW);
        Task<SponsorDto> GetSponsorBySponsorIdAsNoTracking(int sponsorId);
        bool AddSponsor(SponsorDto sponsorDto);
        bool AddSponsorToAthlete(int athleteId, int sponsorId);
        bool UpdateSponsor(int sponsorId, SponsorDto sponsorDto);
        bool DeleteSponsor(SponsorDto sponsorDto);
    }
}
