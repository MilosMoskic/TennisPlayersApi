using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;

namespace TennisPlayers.Application.Mediator.Querries.AthleteQuerries
{
    public class GetAthletesByTournamentHandler : IRequestHandler<GetAthletesByTournamentQuerry, List<AthleteDto>>
    {
        private readonly IAthleteService _athleteService;
        public GetAthletesByTournamentHandler(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }
        public async Task<List<AthleteDto>> Handle(GetAthletesByTournamentQuerry request, CancellationToken cancellationToken)
        {
            return await _athleteService.GetAthletesByTournament(request.TournamentId);
        }
    }
}
