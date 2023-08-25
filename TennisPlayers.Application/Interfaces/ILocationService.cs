using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface ILocationService
    {
        public Task<List<LocationDto>> GetAllLocations();
        public LocationDto GetLocationById(int id);
        public LocationDto GetLocationByName(string name);
        public Task<LocationDto> GetLocationByLocationIdAsNoTracking(int locationId);
        public bool LocationExists(int id);
        public bool LocationExists(string name);
        public bool AddLocation(LocationDto locationDto);
        public bool UpdateLocation(int locationId, LocationDto locationDto);
        public bool DeleteLocation(LocationDto locationDto);
    }
}
