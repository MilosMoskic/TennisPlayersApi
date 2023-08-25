using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.CountryCommands;

namespace TennisPlayers.Application.Mediator.Handlers.CountryHandlers
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, bool>
    {
        private readonly ICountryService _countryService;
        public CreateCountryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public async Task<bool> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            return _countryService.AddCountry(request.CountryDto);
        }
    }
}
