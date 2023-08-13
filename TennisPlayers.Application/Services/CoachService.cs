using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Domain.Interfaces;

namespace TennisPlayers.Application.Services
{
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _coachRepository;
        private readonly IMapper _mapper;

        public CoachService(ICoachRepository coachRepository, IMapper mapper)
        {
            _coachRepository = coachRepository;
            _mapper = mapper;
        }

        public async Task<List<CoachDto>> GetAllCoaches()
        {
            var coaches = await _coachRepository.GetAllCoaches();
            var coachesMapper = _mapper.Map<List<CoachDto>>(coaches);
            return coachesMapper;
        }

        public CoachDto GetCoachById(int id)
        {
            var coach =  _coachRepository.GetCoach(id);
            var coachMapper = _mapper.Map<CoachDto>(coach);
            return coachMapper;
        }
        public async Task<List<CoachDto>> GetCoachesByLastName(string lastName)
        {
            var coaches = _coachRepository.GetCoach(lastName);
            var coachesMapper = _mapper.Map<List<CoachDto>>(coaches);
            return coachesMapper;
        }
        public bool CoachExists(int id)
        {
            return _coachRepository.CoachExists(id);
        }

        public bool CoachExists(string lastName)
        {
            return _coachRepository.CoachExists(lastName);
        }
    }
}
