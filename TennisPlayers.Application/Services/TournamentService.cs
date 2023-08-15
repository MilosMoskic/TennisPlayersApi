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
        private readonly IMapper _mapper;
        public TournamentService(ITournamentRepository tournamentRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
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
    }
}
