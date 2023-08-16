using TennisPlayers.Domain.Models;

namespace TennisPlayers.Domain.Interfaces
{
    public interface ISponsorRepository
    {
        Task<List<Sponsor>> GetSponsors();
        Sponsor GetSponsor(int id);
        Sponsor GetSponsor(string name);
        Task<List<Sponsor>> GetAllSponsorsByNW(decimal netWorth);
        bool SponsorExists(int id);
        bool SponsorExists(string sponsor);
    }
}
