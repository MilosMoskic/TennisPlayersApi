using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;

namespace TennisPlayers.Application.Mediator.Commands.CountryCommands
{
    public class CreateCountryCommand : IRequest<bool>
    {
        public CountryDto CountryDto { get; set; }
        public CreateCountryCommand(CountryDto countryDto)
        {
            CountryDto = countryDto;
        }
    }
}
