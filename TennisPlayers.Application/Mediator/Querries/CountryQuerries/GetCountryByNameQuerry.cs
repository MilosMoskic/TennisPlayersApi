using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.CountryQuerries
{
    public class GetCountryByNameQuerry : IRequest<CountryDto>
    {
        public string Name { get; set; }
        public GetCountryByNameQuerry(string name)
        {
            Name = name;
        }
    }
}
