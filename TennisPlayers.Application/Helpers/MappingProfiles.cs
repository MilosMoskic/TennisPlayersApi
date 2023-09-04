using AutoMapper;
using TennisPlayers.Application.Dto;
using TennisPlayers.Domain.Models;

namespace TennisPlayers.Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Athlete, AthleteDto>().ReverseMap();
            CreateMap<Task<Athlete>, AthleteDto>().ReverseMap();
            CreateMap<Coach, CoachDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Sponsor, SponsorDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Tournament, TournamentDto>().ReverseMap();
            CreateMap<Task<Tournament>, TournamentDto>();
            CreateMap<AthleteTournament, AthleteTournamentDto>().ReverseMap();
            CreateMap<AthleteSponsor, AthleteSponsorDto>().ReverseMap();
            CreateMap<Task<Sponsor>, SponsorDto>().ReverseMap();
        }
    }
}
