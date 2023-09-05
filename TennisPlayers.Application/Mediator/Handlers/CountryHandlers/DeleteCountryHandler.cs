using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.CountryCommands;

namespace TennisPlayers.Application.Mediator.Handlers.CountryHandlers
{
    public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, bool>
    {
        private readonly ICountryService _countryService;
        public DeleteCountryHandler(ICountryService countryService) 
        {
            _countryService = countryService;
        }

        public async Task<bool> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            if (!_countryService.CountryExists(request.CountryId))
                return false;

            var countryToDelete = await _countryService.GetCountryByCountryIdAsNoTracking(request.CountryId);

            return _countryService.DeleteCountry(countryToDelete);
        }
    }
}
