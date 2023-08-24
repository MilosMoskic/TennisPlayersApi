using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.AthleteQuerries
{
    public class GetAthletesBySponsorQuerry : IRequest<List<AthleteDto>>
    {
        public int SponsorId { get; set; }
        public GetAthletesBySponsorQuerry(int sponsorId)
        {
            this.SponsorId = sponsorId;
        }
    }
}
