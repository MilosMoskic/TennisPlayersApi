using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.AthleteSponsorQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.AthleteSponsorHandlers
{
    public class GetSponsorsOfAthleteHandler : IRequestHandler<GetSponsorsOfAthleteQuerry, List<SponsorDto>>
    {
        private readonly IAthleteSponsorService _athleteSponsorService;
        public GetSponsorsOfAthleteHandler(IAthleteSponsorService athleteSponsorService)
        {
            _athleteSponsorService = athleteSponsorService;
        }

        public Task<List<SponsorDto>> Handle(GetSponsorsOfAthleteQuerry request, CancellationToken cancellationToken)
        {
            return _athleteSponsorService.GetSponsorsByAthlete(request.AthleteId);
        }
    }
}
