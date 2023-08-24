using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;

namespace TennisPlayers.Application.Mediator.Querries.AthleteQuerries
{
    public class GetAthleteByIdHandler : IRequestHandler<GetAthleteByIdQuerry, AthleteDto>
    {
        private readonly IAthleteService _athleteService;
        public GetAthleteByIdHandler(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }

        public async Task<AthleteDto> Handle(GetAthleteByIdQuerry request, CancellationToken cancellationToken)
        {
            return _athleteService.GetAthleteById(request.AthleteId);
        }
    }
}
