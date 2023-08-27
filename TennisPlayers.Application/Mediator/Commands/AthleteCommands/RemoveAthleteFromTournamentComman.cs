using MediatR;

namespace TennisPlayers.Application.Mediator.Commands.AthleteCommands
{
    public class RemoveAthleteFromTournamentCommand : IRequest<bool>
    {
        public int AthleteId { get; set; }
        public int TournamentId { get; set; }
    }
}
