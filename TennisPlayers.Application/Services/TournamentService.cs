using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;

namespace TennisPlayers.Application.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public TournamentService(ITournamentRepository tournamentRepository,ILocationRepository locationRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public bool AddTournament(int locationId, TournamentDto tournament)
        {
            var location = _locationRepository.GetLocation(locationId);

            var tournamentMapped = _mapper.Map<Tournament>(tournament);
            return _tournamentRepository.AddTournament(location, tournamentMapped);
        }

        public bool DeleteTournament(TournamentDto tournamentDto)
        {
            var tournmanet = _mapper.Map<Tournament>(tournamentDto);
            return _tournamentRepository.DeleteTournament(tournmanet);
        }

        public async Task<List<TournamentDto>> GetAllTournaments()
        {
            var tournaments = await _tournamentRepository.GetTournaments();
            var tournamentsMapped = _mapper.Map<List<TournamentDto>>(tournaments);
            return tournamentsMapped;
        }

        public TournamentDto GetTournamentById(int id)
        {
            var tournament = _tournamentRepository.GetTournament(id);
            var tournamentMapped = _mapper.Map<TournamentDto>(tournament);
            return tournamentMapped;
        }

        public TournamentDto GetTournamentByName(string name)
        {
            var tournament = _tournamentRepository.GetTournament(name);
            var tournamentMapped = _mapper.Map<TournamentDto>(tournament);
            return tournamentMapped;
        }

        public bool TournamentExists(int id)
        {
            return _tournamentRepository.TournamentExists(id);
        }

        public bool TournamentExists(string name)
        {
            return _tournamentRepository.TournamentExists(name);
        }

        public bool UpdateTournament(int tournamentId, TournamentDto tournamentDto)
        {
            var tournamentMapped = _mapper.Map<Tournament>(tournamentDto);
            tournamentMapped.Id = tournamentId;

            return _tournamentRepository.UpdateTournament(tournamentMapped);
        }
        public async Task<TournamentDto> GetTournamentByTournamentIdAsNoTracking(int tournamentId)
        {
            var tournament = await _tournamentRepository.GetTournamentByTournamentIdAsNoTracking(tournamentId);
            var tournamentMapper = _mapper.Map<TournamentDto>(tournament);
            return tournamentMapper;
        }
    }
}
