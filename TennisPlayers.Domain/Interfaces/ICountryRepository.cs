using TennisPlayers.Domain.Models;

namespace TennisPlayers.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountries();
        Country GetCountry(int id);
        Country GetCountry(string name);
        bool CountryExists(int id);
        bool CountryExists(string country);
    }
}
