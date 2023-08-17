using Microsoft.EntityFrameworkCore;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;
using TennisPlayers.Infastructure.Context;

namespace TennisPlayers.Infastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly TennisPlayersContext _context;

        public CountryRepository(TennisPlayersContext context)
        {
            _context = context;
        }

        public bool AddCountry(Country country)
        {
            _context.Countries.Add(country);
            return Save();
        }

        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public bool CountryExists(string country)
        {
            return _context.Countries.Any(c => c.Name == country);
        }

        public Task<List<Country>> GetCountries()
        {
            return _context.Countries.ToListAsync();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountry(string name)
        {
            return _context.Countries.Where(c => c.Name == name).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return Save();
        }
    }
}
