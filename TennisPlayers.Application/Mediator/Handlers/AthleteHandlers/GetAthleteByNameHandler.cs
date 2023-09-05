using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.AthleteQuerries;

namespace TennisPlayers.Application.Mediator.Querries.AthleteHandlers
{
    public class GetAthleteByNameHandler : IRequestHandler<GetAthleteByNameQuerry, AthleteDto>
    {
        private readonly IAthleteService _athleteService;
        public GetAthleteByNameHandler(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }

        public async Task<AthleteDto> Handle(GetAthleteByNameQuerry request, CancellationToken cancellationToken)
        {
            return _athleteService.GetAthleteByName(request.Name);
        }
    }
}
