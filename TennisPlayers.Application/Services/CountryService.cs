using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Domain.Interfaces;

namespace TennisPlayers.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public bool CountryExists(int id)
        {
            return _countryRepository.CountryExists(id);
        }

        public bool CountryExists(string country)
        {
            return _countryRepository.CountryExists(country);
        }

        public async Task<List<CountryDto>> GetAllCountries()
        {
            var countries = await _countryRepository.GetCountries();
            var countriesMapper = _mapper.Map<List<CountryDto>>(countries);
            return countriesMapper;
        }

        public CountryDto GetCountryById(int id)
        {
            var country = _countryRepository.GetCountry(id);
            var countryMapper = _mapper.Map<CountryDto>(country);
            return countryMapper;
        }

        public CountryDto GetCountryByName(string name)
        {
            var country = _countryRepository.GetCountry(name);
            var countryMapper = _mapper.Map<CountryDto>(country);
            return countryMapper;
        }
    }
}
