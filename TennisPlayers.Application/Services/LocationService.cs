using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;

namespace TennisPlayers.Application.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public LocationService(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public bool AddLocation(LocationDto locationDto)
        {
            var locationMapped = _mapper.Map<Location>(locationDto);
            return _locationRepository.AddLocation(locationMapped);
        }

        public bool DeleteLocation(LocationDto locationDto)
        {
            var location = _mapper.Map<Location>(locationDto);
            return _locationRepository.DeleteLocation(location);
        }

        public async Task<List<LocationDto>> GetAllLocations()
        {
            var locations = await _locationRepository.GetAllLocations();
            var locationsMapped = _mapper.Map<List<LocationDto>>(locations);
            return locationsMapped;
        }

        public LocationDto GetLocationById(int id)
        {
            var location = _locationRepository.GetLocation(id);
            var locationMapped = _mapper.Map<LocationDto>(location);
            return locationMapped;
        }

        public LocationDto GetLocationByName(string name)
        {
            var location = _locationRepository.GetLocation(name);
            var locationMapped = _mapper.Map<LocationDto>(location);
            return locationMapped;
        }
        public bool LocationExists(int id)
        {
            return _locationRepository.LocationExists(id);
        }
        public bool LocationExists(string name)
        {
            return _locationRepository.LocationExists(name);
        }

        public bool UpdateLocation(int locationId, LocationDto locationDto)
        {
            var locationMapped = _mapper.Map<Location>(locationDto);
            locationMapped.Id = locationId;

            return _locationRepository.UpdateLocation(locationMapped);
        }
    }
}
