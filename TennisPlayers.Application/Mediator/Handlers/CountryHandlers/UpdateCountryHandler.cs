using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.CountryCommands;

namespace TennisPlayers.Application.Mediator.Handlers.CountryHandlers
{
    public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, bool>
    {
        private readonly ICountryService _countryService;
        public UpdateCountryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<bool> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            if (!_countryService.CountryExists(request.CountryId))
                return false;

            return _countryService.UpdateCountry(request.CountryId, request.CountryDto);
        }
    }
}
