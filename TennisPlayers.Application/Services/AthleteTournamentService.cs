using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;
using TennisPlayers.Infastructure.Repositories;

namespace TennisPlayers.Application.Services
{
    public class AthleteTournamentService : IAthleteTournamentService
    {
        private readonly IAthleteRepository _athleteRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IAthleteTournamentRepository _athleteTournamentRepository;
        private readonly IMapper _mapper;
        public AthleteTournamentService(IAthleteRepository athleteRepository,
            ITournamentRepository tournamentRepository,
            IAthleteTournamentRepository athleteTournamentRepository,
            IMapper mapper)
        {
            _athleteRepository = athleteRepository;
            _tournamentRepository = tournamentRepository;
            _athleteTournamentRepository = athleteTournamentRepository;
            _mapper = mapper;
        }

        public bool AddAthleteToTournament(int athleteId, int tournamentId, AthleteTournamentDto athleteTournamentDto)
        {
            var athlete = _athleteRepository.GetAthlete(athleteId);
            var tournament = _tournamentRepository.GetTournament(tournamentId);
            var athleteMapped = _mapper.Map<Athlete>(athlete);
            var tournamentMapped = _mapper.Map<Tournament>(tournament);

            var athleteTournamentMapped = _mapper.Map<AthleteTournament>(athleteTournamentDto);

            athleteTournamentMapped.Tournament = tournamentMapped;
            athleteTournamentMapped.Athlete = athleteMapped;

            return _athleteTournamentRepository.AddAthleteToTournament(athleteTournamentMapped);
        }

        public async Task<List<AthleteDto>> GetAthletesByTournament(int tournamentId)
        {
            var athletes = _athleteTournamentRepository.GetAthletesByTournament(tournamentId);
            var athletesMapped = _mapper.Map<List<AthleteDto>>(athletes);
            return athletesMapped;
        }

        public bool RemoveAthleteFromTournament(int athleteId, int tournamentId)
        {
            return _athleteTournamentRepository.RemoveAthleteFromTournament(athleteId, tournamentId);
        }
    }
}
