using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;

namespace TennisPlayers.Application.Services
{
    public class SponsorService : ISponsorService
    {
        public readonly ISponsorRepository _sponsorRepository;
        public readonly IMapper _mapper;
        public SponsorService(ISponsorRepository sponsorRepository, IMapper mapper)
        {
            _sponsorRepository = sponsorRepository;
            _mapper = mapper;
        }

        public bool AddSponsor(SponsorDto sponsorDto)
        {
            var sponsorMapped = _mapper.Map<Sponsor>(sponsorDto);
            return _sponsorRepository.AddSponsor(sponsorMapped);
        }

        public async Task<List<SponsorDto>> GetAllSponsors()
        {
            var sponsors = await _sponsorRepository.GetSponsors();
            var sponsorsMapped = _mapper.Map<List<SponsorDto>>(sponsors);
            return sponsorsMapped;
        }

        public SponsorDto GetSponsorById(int id)
        {
            var sponsor = _sponsorRepository.GetSponsor(id);
            var sponsorMapped = _mapper.Map<SponsorDto>(sponsor);
            return sponsorMapped;
        }

        public SponsorDto GetSponsorByName(string name)
        {
            var sponsor = _sponsorRepository.GetSponsor(name);
            var sponsorMapped = _mapper.Map<SponsorDto>(sponsor);
            return sponsorMapped;
        }

        public async Task<List<SponsorDto>> GetSponsorsByNW(decimal NW)
        {
            var sponsors = await _sponsorRepository.GetAllSponsorsByNW(NW);
            var sponsorsMapped = _mapper.Map<List<SponsorDto>>(sponsors);
            return sponsorsMapped;
        }

        public bool SponsorExists(int id)
        {
            return _sponsorRepository.SponsorExists(id);
        }

        public bool SponsorExists(string sponsor)
        {
            return _sponsorRepository.SponsorExists(sponsor);
        }
    }
}
