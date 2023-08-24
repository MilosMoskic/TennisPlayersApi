using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.CountryQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.CountryHandlers
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuerry, List<CountryDto>>
    {
        private readonly ICountryService _countryService;
        public GetAllCountriesHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public Task<List<CountryDto>> Handle(GetAllCountriesQuerry request, CancellationToken cancellationToken)
        {
            return _countryService.GetAllCountries();
        }
    }
}
