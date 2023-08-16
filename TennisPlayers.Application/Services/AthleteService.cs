using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;

namespace TennisPlayers.Application.Services
{
    public class AthleteService : IAthleteService
    {
        private readonly IAthleteRepository _athleteRepository;
        private readonly IMapper _mapper;

        public AthleteService(IAthleteRepository athleteRepository, IMapper mapper)
        {
            _athleteRepository = athleteRepository;
            _mapper = mapper;
        }

        public bool AthleteExists(int id)
        {
            return _athleteRepository.AthleteExists(id);
        }

        public bool AthleteExists(string name)
        {
            return _athleteRepository.AthleteExists(name);
        }

        public async Task<List<AthleteDto>> GetAllAthletes()
        {
            var athletes = await _athleteRepository.GetAllAthletes();
            var athletesMapped = _mapper.Map<List<AthleteDto>>(athletes);
            return athletesMapped;
        }

        public AthleteDto GetAthleteById(int id)
        {
            var athlete = _athleteRepository.GetAthlete(id);
            var athleteMapped = _mapper.Map<AthleteDto>(athlete);
            return athleteMapped;
        }

        public AthleteDto GetAthleteByName(string name)
        {
            var athlete = _athleteRepository.GetAthlete(name);
            var athleteMapped = _mapper.Map<AthleteDto>(athlete);
            return athleteMapped;
        }

        public AthleteDto GetAthleteByRanking(int ranking)
        {
            var athlete = _athleteRepository.GetAthlete(ranking);
            var athleteMapped = _mapper.Map<AthleteDto>(athlete);
            return athleteMapped;
        }

        public async Task<List<AthleteDto>> GetAthletesBySponsor(int sponsorId)
        {
            var athletes = _athleteRepository.GetAthletesBySponsor(sponsorId);
            var athletesMapped = _mapper.Map<List<AthleteDto>>(athletes);
            return athletesMapped;
        }

        public async Task<List<AthleteDto>> GetAthletesByTournament(int tournamentId)
        {
            var athletes = _athleteRepository.GetAthletesByTournament(tournamentId);
            var athletesMapped = _mapper.Map<List<AthleteDto>>(athletes);
            return athletesMapped;
        }

        public decimal GetAthleteWinPercent(string name)
        {
            var athlete = _athleteRepository.GetAthleteWinPercent(name);
            return athlete;
        }
    }
}
