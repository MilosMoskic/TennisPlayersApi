using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.AthleteSponsorQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.AthleteSponsorHandlers
{
    public class GetAthletesBySponsorHandler : IRequestHandler<GetAthletesBySponsorQuerry, List<AthleteDto>>
    {
        private readonly IAthleteSponsorService _athleteSponsorService;
        public GetAthletesBySponsorHandler(IAthleteSponsorService athleteSponsorService)
        {
            _athleteSponsorService = athleteSponsorService;
        }

        public Task<List<AthleteDto>> Handle(GetAthletesBySponsorQuerry request, CancellationToken cancellationToken)
        {
            return _athleteSponsorService.GetAthletesBySponsor(request.SponsorId);
        }
    }
}
