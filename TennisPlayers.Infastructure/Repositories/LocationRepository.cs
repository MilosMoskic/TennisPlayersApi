﻿using Microsoft.EntityFrameworkCore;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;
using TennisPlayers.Infastructure.Context;

namespace TennisPlayers.Infastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly TennisPlayersContext _context;
        public LocationRepository(TennisPlayersContext context)
        {
            _context = context;
        }
        public Location GetLocation(int id)
        {
            return _context.Locations.Where(l => l.Id == id).FirstOrDefault();
        }

        public Location GetLocation(string name)
        {
            return _context.Locations.Where(l => l.CityName == name).FirstOrDefault();
        }

        public Task<List<Location>> GetAllLocations()
        {
            return _context.Locations.ToListAsync();
        }

        public bool LocationExists(int id)
        {
            return _context.Locations.Any(l => l.Id == id);
        }

        public bool LocationExists(string name)
        {
            return _context.Locations.Any(l => l.CityName == name);
        }

        public bool AddLocation(Location location)
        {
            _context.Locations.Add(location);
            return Save();
        }
        public async Task<Location> GetLocationByLocationIdAsNoTracking(int locationId)
        {
            return await _context.Locations.Where(c => c.Id == locationId).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateLocation(Location location)
        {
            _context.Update(location);
            return Save();
        }

        public bool DeleteLocation(Location location)
        {
            _context.Remove(location);
            return Save();
        }
    }
}
