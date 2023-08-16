using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Domain.Models;

namespace TennisPlayers.Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Athlete, AthleteDto>();
            CreateMap<Coach, CoachDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<Sponsor, SponsorDto>();
            CreateMap<Location, LocationDto>();
            CreateMap<Tournament, TournamentDto>();
        }
    }
}
