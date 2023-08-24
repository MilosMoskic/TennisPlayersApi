using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.CoachQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.CoachHandlers
{
    public class GetAllCoachesHandler : IRequestHandler<GetAllCoachesQuerry, List<CoachDto>>
    {
        private readonly ICoachService _coachService;
        public GetAllCoachesHandler(ICoachService coachService)
        {
            _coachService = coachService;
        }
        public Task<List<CoachDto>> Handle(GetAllCoachesQuerry request, CancellationToken cancellationToken)
        {
            return _coachService.GetAllCoaches();
        }
    }
}
