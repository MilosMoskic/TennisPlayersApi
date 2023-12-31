﻿using TennisPlayers.Domain.Models;

namespace TennisPlayers.Domain.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocations();
        Location GetLocation(int id);
        Location GetLocation(string name);
        Task<Location> GetLocationByLocationIdAsNoTracking(int locationId);
        bool LocationExists(int id);
        bool LocationExists(string name);
        bool AddLocation(Location location);
        bool UpdateLocation(Location location);
        bool DeleteLocation(Location location);
        bool Save();
    }
}
