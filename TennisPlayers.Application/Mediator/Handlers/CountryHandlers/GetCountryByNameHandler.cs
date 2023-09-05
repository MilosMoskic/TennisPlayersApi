using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.CountryQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.CountryHandlers
{
    public class GetCountryByNameHandler : IRequestHandler<GetCountryByNameQuerry, CountryDto>
    {
        private readonly ICountryService _countryService;
        public GetCountryByNameHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<CountryDto> Handle(GetCountryByNameQuerry request, CancellationToken cancellationToken)
        {
            return _countryService.GetCountryByName(request.Name);
        }
    }
}
