using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;
using TennisPlayers.Infastructure.Repositories;

namespace TennisPlayers.Application.Services
{
    public class AthleteSponsorService : IAthleteSponsorService
    {
        private readonly IAthleteRepository _athleteRepository;
        private readonly ISponsorRepository _sponsorRepository;
        private readonly IAthleteSponsorRepository _athleteSponsorRepository;
        private readonly IMapper _mapper;
        public AthleteSponsorService(IAthleteRepository athleteRepository, ISponsorRepository sponsorRepository, IAthleteSponsorRepository athleteSponsorRepository, IMapper mapper)
        {
            _athleteRepository = athleteRepository;
            _sponsorRepository = sponsorRepository;
            _athleteSponsorRepository = athleteSponsorRepository;
            _mapper = mapper;
        }

        public bool AddSponsorToAthlete(int athleteId, int sponsorId, AthleteSponsorDto athleteSponsorDto)
        {
            var athlete = _athleteRepository.GetAthlete(athleteId);
            var sponsor = _sponsorRepository.GetSponsor(sponsorId);
            var athleteMapped = _mapper.Map<Athlete>(athlete);
            var sponsorMapped = _mapper.Map<Sponsor>(sponsor);

            var athleteSponsorMapped = _mapper.Map<AthleteSponsor>(athleteSponsorDto);

            athleteSponsorMapped.Sponsor = sponsorMapped;
            athleteSponsorMapped.Athlete = athleteMapped;

            return _athleteSponsorRepository.AddSponsorToAthlete(athleteSponsorMapped);
        }

        public async Task<List<AthleteDto>> GetAthletesBySponsor(int sponsorId)
        {
            var athletes = _athleteSponsorRepository.GetAthletesBySponsor(sponsorId);
            var athletesMapped = _mapper.Map<List<AthleteDto>>(athletes);
            return athletesMapped;
        }
        public async Task<List<SponsorDto>> GetSponsorsByAthlete(int athleteId)
        {
            var athletes = _athleteSponsorRepository.GetSponsorsOfAthlete(athleteId);
            var athletesMapped = _mapper.Map<List<SponsorDto>>(athletes);
            return athletesMapped;
        }
        public bool RemoveSponsorFromAthlete(int athleteId, int sponsorId)
        {
            return _athleteSponsorRepository.RemoveSponsorFromAthlete(athleteId, sponsorId);
        }
    }
}
