using TennisPlayers.Domain.Models;

namespace TennisPlayers.Domain.Interfaces
{
    public interface ISponsorRepository
    {
        Task<List<Sponsor>> GetSponsors();
        Sponsor GetSponsor(int id);
        Sponsor GetSponsor(string name);
        Task<List<Sponsor>> GetAllSponsorsByNW(decimal netWorth);
        Sponsor GetSponsorBySponsorIdAsNoTracking(int sponsorId);
        bool SponsorExists(int id);
        bool SponsorExists(string sponsor);
        bool AddSponsor(Sponsor sponsor);
        bool AddSponsorToAthlete(Athlete athlete, Sponsor sponsor);
        bool UpdateSponsor(Sponsor sponsor);
        bool DeleteSponsor(Sponsor sponsor);
        bool Save();
    }
}
