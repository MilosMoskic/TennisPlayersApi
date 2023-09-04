using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.AthleteSponsorQuerries
{
    public class GetSponsorsOfAthleteQuerry : IRequest<List<SponsorDto>>
    {
        public int AthleteId { get; set; }
        public GetSponsorsOfAthleteQuerry(int athleteId)
        {
            AthleteId = athleteId;
        }
    }
}
