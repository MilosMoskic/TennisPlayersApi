using TennisPlayers.Domain.Models;

namespace TennisPlayers.Infastructure.Repositories
{
    public interface IAthleteSponsorRepository
    {
        ICollection<Athlete> GetAthletesBySponsor(int sponsorId);
        ICollection<Sponsor> GetSponsorsOfAthlete(int athleteId);
        bool AddSponsorToAthlete(AthleteSponsor athleteSponsor);
        bool RemoveSponsorFromAthlete(int athleteId, int sponsorId);
        bool Save();
    }
}