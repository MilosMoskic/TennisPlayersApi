using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.AthleteQuerries;

namespace TennisPlayers.Application.Mediator.Querries.AthleteHandlers
{
    public class GetAthletesBySponsorHandler : IRequestHandler<GetAthletesBySponsorQuerry, List<AthleteDto>>
    {
        private readonly IAthleteService _athleteService;
        public GetAthletesBySponsorHandler(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }

        public Task<List<AthleteDto>> Handle(GetAthletesBySponsorQuerry request, CancellationToken cancellationToken)
        {
            return _athleteService.GetAthletesBySponsor(request.SponsorId);
        }
    }
}
