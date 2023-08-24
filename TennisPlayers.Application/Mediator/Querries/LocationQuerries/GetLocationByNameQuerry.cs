using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.LocationQuerries
{
    public class GetLocationByNameQuerry : IRequest<LocationDto>
    {
        public string Name { get; set; }
        public GetLocationByNameQuerry(string name)
        {
            Name = name;
        }
    }
}
