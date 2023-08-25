using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;

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

        public bool AddCountry(CountryDto countryDto)
        {
            var countryMapped = _mapper.Map<Country>(countryDto);
            return _countryRepository.AddCountry(countryMapped);
        }

        public bool CountryExists(int id)
        {
            return _countryRepository.CountryExists(id);
        }

        public bool CountryExists(string country)
        {
            return _countryRepository.CountryExists(country);
        }

        public bool DeleteCountry(CountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            return _countryRepository.DeleteCountry(country);
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

        public bool UpdateCountry(int countryId, CountryDto countryDto)
        {
            var countryMapped = _mapper.Map<Country>(countryDto);
            countryMapped.Id = countryId;

            return _countryRepository.UpdateCountry(countryMapped);
        }

        public async Task<CountryDto> GetCountryByCountryIdAsNoTracking(int countryId)
        {
            var country = await _countryRepository.GetCountryByCountryIdAsNoTracking(countryId);
            var countryMapper = _mapper.Map<CountryDto>(country);
            return countryMapper;
        }
    }
}
