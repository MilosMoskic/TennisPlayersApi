﻿using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;

namespace TennisPlayers.Application.Services
{
    public class AthleteService : IAthleteService
    {
        private readonly IAthleteRepository _athleteRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICoachRepository _coachRepository;
        private readonly IMapper _mapper;

        public AthleteService(IAthleteRepository athleteRepository, 
            ICoachRepository coachRepository, 
            ICountryRepository countryRepository,
            IMapper mapper)
        {
            _athleteRepository = athleteRepository;
            _coachRepository = coachRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public bool AddAthlete(int coachId, int countryId, AthleteDto athlete)
        {
            var coach = _coachRepository.GetCoach(coachId);
            var country = _countryRepository.GetCountry(countryId);

            var athleteMapped = _mapper.Map<Athlete>(athlete);
            return _athleteRepository.AddAthlete(coach, country, athleteMapped);
        }

        public bool AthleteExists(int id)
        {
            return _athleteRepository.AthleteExists(id);
        }

        public bool AthleteExists(string name)
        {
            return _athleteRepository.AthleteExists(name);
        }

        public bool DeleteAthlete(AthleteDto athleteDto)
        {
            var athlete = _mapper.Map<Athlete>(athleteDto);
            return _athleteRepository.DeleteAthlete(athlete);
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
            var athlete = _athleteRepository.GetAthleteByRanking(ranking);
            var athleteMapped = _mapper.Map<AthleteDto>(athlete);
            return athleteMapped;
        }

        public async Task<List<AthleteDto>> GetAthletesBySponsor(int sponsorId)
        {
            var athletes = _athleteRepository.GetAthletesBySponsor(sponsorId);
            var athletesMapped = _mapper.Map<List<AthleteDto>>(athletes);
            return athletesMapped;
        }

        public decimal GetAthleteWinPercent(string name)
        {
            var athlete = _athleteRepository.GetAthleteWinPercent(name);
            return athlete;
        }

        public async Task<AthleteDto> GetAthleteByAthleteIdAsNoTracking(int athleteId)
        {
            var athlete = await _athleteRepository.GetAthleteByAthleteIdAsNoTracking(athleteId);
            var athleteMapper = _mapper.Map<AthleteDto>(athlete);
            return athleteMapper;
        }

        public bool UpdateAthlete(int athleteId, AthleteDto athleteDto)
        {
            var athleteMapped = _mapper.Map<Athlete>(athleteDto);
            athleteMapped.Id = athleteId;

            return _athleteRepository.UpdateAthlete(athleteMapped);
        }

        public bool RemoveAthleteFromSponsor(int athleteId, int sponsorId)
        {
            return _athleteRepository.RemoveAthleteFromSponsor(athleteId, sponsorId);
        }
    }
}
