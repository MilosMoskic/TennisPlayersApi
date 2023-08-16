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
            CreateMap<CoachDto, Coach>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<Sponsor, SponsorDto>();
            CreateMap<SponsorDto, Sponsor>();
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
            CreateMap<Tournament, TournamentDto>();
        }
    }
}
