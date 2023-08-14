using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface ILocationService
    {
        public Task<List<LocationDto>> GetAllLocations();
        public LocationDto GetLocationById(int id);
        public LocationDto GetLocationByName(string name);
        public bool LocationExists(int id);
        public bool LocationExists(string name);
    }
}
