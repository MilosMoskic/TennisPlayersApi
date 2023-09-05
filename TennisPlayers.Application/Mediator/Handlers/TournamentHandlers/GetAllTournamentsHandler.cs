using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.TournamentQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.TournamentHandlers
{
    public class GetAllTournamentsHandler : IRequestHandler<GetAllTournamentsQuerry, List<TournamentDto>>
    {
        private readonly ITournamentService _tournamentService;
        public GetAllTournamentsHandler(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public Task<List<TournamentDto>> Handle(GetAllTournamentsQuerry request, CancellationToken cancellationToken)
        {
            return _tournamentService.GetAllTournaments();
        }
    }
}
