using TennisPlayers.Domain.Models;

namespace TennisPlayers.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountries();
        Country GetCountry(int id);
        Country GetCountry(string name);
        Task<Country> GetCountryByCountryIdAsNoTracking(int countryId);
        bool CountryExists(int id);
        bool CountryExists(string country);
        bool AddCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(Country country);
        bool Save();
    }
}
