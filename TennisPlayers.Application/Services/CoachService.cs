﻿using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;

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

        public bool AddCoach(CoachDto coachDto)
        {
            var coachMapped = _mapper.Map<Coach>(coachDto);
            return _coachRepository.AddCoach(coachMapped);
        }

        public bool UpdateCoach(int coachId, CoachDto coachDto)
        {
            var coachMapped = _mapper.Map<Coach>(coachDto);
            coachMapped.Id = coachId;

            return _coachRepository.UpdateCoach(coachMapped);
        }

        public bool DeleteCoach(CoachDto coachDto)
        {
            var coach = _mapper.Map<Coach>(coachDto);
            return _coachRepository.DeleteCoach(coach);
        }

        public async Task<CoachDto> GetCoachByCoachIdAsNoTracking(int coachId)
        {
            var coach = await _coachRepository.GetCoachByCoachIdAsNoTracking(coachId);
            var coachMapper = _mapper.Map<CoachDto>(coach);
            return coachMapper;
        }
    }
}
