using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.CountryQuerries
{
    public class GetCountryByIdQuerry : IRequest<CountryDto>
    {
        public int CountryId { get; set; }
        public GetCountryByIdQuerry(int countryId)
        {
            CountryId = countryId;        
        }
    }
}
