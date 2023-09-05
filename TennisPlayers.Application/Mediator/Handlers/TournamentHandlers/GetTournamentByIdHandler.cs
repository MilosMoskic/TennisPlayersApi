using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.TournamentQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.TournamentHandlers
{
    public class GetTournamentByIdHandler : IRequestHandler<GetTournamentByIdQuerry, TournamentDto>
    {
        private readonly ITournamentService _tournamentService;
        public GetTournamentByIdHandler(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public async Task<TournamentDto> Handle(GetTournamentByIdQuerry request, CancellationToken cancellationToken)
        {
            return _tournamentService.GetTournamentById(request.TournamentId);
        }
    }
}
