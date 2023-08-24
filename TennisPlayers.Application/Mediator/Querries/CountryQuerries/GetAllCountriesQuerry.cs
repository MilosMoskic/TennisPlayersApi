using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Querries.CountryQuerries
{
    public class GetAllCountriesQuerry : IRequest<List<CountryDto>>
    {
    }
}
