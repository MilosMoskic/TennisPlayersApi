using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface ILocationService
    {
        Task<List<LocationDto>> GetAllLocations();
        LocationDto GetLocationById(int id);
        LocationDto GetLocationByName(string name);
        Task<LocationDto> GetLocationByLocationIdAsNoTracking(int locationId);
        bool LocationExists(int id);
        bool LocationExists(string name);
        bool AddLocation(LocationDto locationDto);
        bool UpdateLocation(int locationId, LocationDto locationDto);
        bool DeleteLocation(LocationDto locationDto);
    }
}
