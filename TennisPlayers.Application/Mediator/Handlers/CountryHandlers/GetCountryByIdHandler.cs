using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.CountryQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.CountryHandlers
{
    public class GetCountryByIdHandler : IRequestHandler<GetCountryByIdQuerry, CountryDto>
    {
        private readonly ICountryService _countryService;
        public GetCountryByIdHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public async Task<CountryDto> Handle(GetCountryByIdQuerry request, CancellationToken cancellationToken)
        {
            return _countryService.GetCountryById(request.CountryId);
        }
    }
}
