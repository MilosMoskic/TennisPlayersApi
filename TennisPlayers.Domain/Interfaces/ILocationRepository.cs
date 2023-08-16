using TennisPlayers.Domain.Models;

namespace TennisPlayers.Domain.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocations();
        Location GetLocation(int id);
        Location GetLocation(string name);
        bool LocationExists(int id);
        bool LocationExists(string name);
        bool AddLocation(Location location);
        bool Save();
    }
}
