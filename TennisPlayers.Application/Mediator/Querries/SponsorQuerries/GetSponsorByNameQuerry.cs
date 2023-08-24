using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.SponsorQuerries
{
    public class GetSponsorByNameQuerry : IRequest<SponsorDto>
    {
        public string Name { get; set; }
        public GetSponsorByNameQuerry(string name)
        {
            Name = name;
        }
    }
}
