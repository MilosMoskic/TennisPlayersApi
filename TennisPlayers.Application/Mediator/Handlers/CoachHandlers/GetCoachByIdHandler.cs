using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.CoachQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.CoachHandlers
{
    public class GetCoachByIdHandler : IRequestHandler<GetCoachByIdQuerry, CoachDto>
    {
        private readonly ICoachService _coachService;
        public GetCoachByIdHandler(ICoachService coachService)
        {
            _coachService = coachService;
        }

        public async Task<CoachDto> Handle(GetCoachByIdQuerry request, CancellationToken cancellationToken)
        {
            return _coachService.GetCoachById(request.CoachId);
        }
    }
}
