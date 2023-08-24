using MediatR;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.AthleteQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.AthleteHandlers
{
    public class GetAthleteWinPercentHandler : IRequestHandler<GetAthleteWinPercentQuerry, decimal>
    {
        private readonly IAthleteService _athleteService;
        public GetAthleteWinPercentHandler(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }
        public async Task<decimal> Handle(GetAthleteWinPercentQuerry request, CancellationToken cancellationToken)
        {
            return _athleteService.GetAthleteWinPercent(request.LastName);
        }
    }
}
