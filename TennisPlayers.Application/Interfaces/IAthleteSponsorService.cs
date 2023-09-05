using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface IAthleteSponsorService
    {
        bool AddSponsorToAthlete(int athleteId, int sponsorId, AthleteSponsorDto athleteSponsorDto);
        Task<List<AthleteDto>> GetAthletesBySponsor(int sponsorId);
        Task<List<SponsorDto>> GetSponsorsByAthlete(int athleteId);
        bool RemoveSponsorFromAthlete(int athleteId, int sponsorId);
    }
}
