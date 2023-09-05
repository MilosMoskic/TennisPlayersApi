using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.TournamentQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.TournamentHandlers
{
    public class GetTournamentByNameHandler : IRequestHandler<GetTournamentByNameQuerry, TournamentDto>
    {
        private readonly ITournamentService _tournamentService;
        public GetTournamentByNameHandler(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public async Task<TournamentDto> Handle(GetTournamentByNameQuerry request, CancellationToken cancellationToken)
        {
            return _tournamentService.GetTournamentByName(request.Name);
        }
    }
}
