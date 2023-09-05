using MediatR;

namespace TennisPlayers.Application.Mediator.Commands.TournamentCommands
{
    public class DeleteTournamentCommand : IRequest<bool>
    {
        public int TournamentId { get; set; }
        public DeleteTournamentCommand(int tournamentId)
        {
            TournamentId = tournamentId;
        }
    }
}
