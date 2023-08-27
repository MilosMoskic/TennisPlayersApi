using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.AthleteQuerries;

namespace TennisPlayers.Application.Mediator.Querries.AthleteHandlers
{
    public class GetAllAthletesHandler : IRequestHandler<GetAllAthletesQuerry, List<AthleteDto>>
    {
        private readonly IAthleteService _athleteService;
        public GetAllAthletesHandler(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }

        public Task<List<AthleteDto>> Handle(GetAllAthletesQuerry request, CancellationToken cancellationToken)
        {
            return _athleteService.GetAllAthletes();
        }
    }
}
