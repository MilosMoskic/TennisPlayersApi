using MediatR;

namespace TennisPlayers.Application.Mediator.Commands.CountryCommands
{
    public class DeleteCountryCommand : IRequest<bool>
    {
        public int CountryId { get; set; }
        public DeleteCountryCommand(int countryId)
        {
            CountryId = countryId;
        }
    }
}
