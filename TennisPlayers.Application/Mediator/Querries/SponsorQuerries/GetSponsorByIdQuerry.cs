using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;

namespace TennisPlayers.Application.Mediator.Querries.SponsorQuerries
{
    public class GetSponsorByIdQuerry : IRequest<SponsorDto>
    {
        public int SponsorId { get; set; }
        public GetSponsorByIdQuerry(int sponsorId)
        {
            SponsorId = sponsorId;
        }
    }
}
