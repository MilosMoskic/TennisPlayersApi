using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryDto>> GetAllCountries();
        CountryDto GetCountryById(int id);
        CountryDto GetCountryByName(string name);
        Task<CountryDto> GetCountryByCountryIdAsNoTracking(int countryId);
        bool CountryExists(int id);
        bool CountryExists(string country);
        bool AddCountry(CountryDto countryDto);
        bool UpdateCountry(int countryId, CountryDto countryDto);
        bool DeleteCountry(CountryDto countryDto);
    }
}
