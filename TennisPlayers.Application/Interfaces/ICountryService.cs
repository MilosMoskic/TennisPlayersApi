using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface ICountryService
    {
        public Task<List<CountryDto>> GetAllCountries();
        public CountryDto GetCountryById(int id);
        public CountryDto GetCountryByName(string name);
        public bool CountryExists(int id);
        public bool CountryExists(string country);
        public bool AddCountry(CountryDto countryDto);
        public bool UpdateCountry(int countryId, CountryDto countryDto);
    }
}
