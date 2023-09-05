using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.CountryCommands
{
    public class UpdateCountryCommand : IRequest<bool>
    {
        public int CountryId { get; set; }
        public CountryDto CountryDto { get; set; }
        public UpdateCountryCommand(int countryId, CountryDto countryDto)
        {
            CountryId = countryId;
            CountryDto = countryDto;
        }
    }
}
