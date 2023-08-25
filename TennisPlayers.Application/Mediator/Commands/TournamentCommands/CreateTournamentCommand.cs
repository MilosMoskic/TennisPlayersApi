using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.TournamentCommands
{
    public class CreateTournamentCommand : IRequest<bool>
    {
        public int LocationId { get; set; }
        public TournamentDto TournamentDto { get; set; }
        public CreateTournamentCommand(TournamentDto tournamentDto, int locationId)
        {
            TournamentDto = tournamentDto;
            LocationId = locationId;
        }
    }
}
