using MediatR;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Mediator.Commands.TournamentCommands
{
    public class UpdateTournamentCommand : IRequest<bool>
    {
        public int TournamentId { get; set; }
        public TournamentDto TournamentDto { get; set; }
        public UpdateTournamentCommand(int tournamentId, TournamentDto tournamentDto)
        {
            TournamentId = tournamentId;
            TournamentDto = tournamentDto;
        }
    }
}
