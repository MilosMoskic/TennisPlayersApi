using MediatR;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.CoachQuerries;

namespace TennisPlayers.Application.Mediator.Handlers.CoachHandlers
{
    public class GetCoachesByLastNameHandler : IRequestHandler<GetCoachesByLastNameQuerry, List<CoachDto>>
    {
        private readonly ICoachService _coachService;
        public GetCoachesByLastNameHandler(ICoachService coachService)
        {
            _coachService = coachService;
        }

        public async Task<List<CoachDto>> Handle(GetCoachesByLastNameQuerry request, CancellationToken cancellationToken)
        {
            return await _coachService.GetCoachesByLastName(request.LastName);
        }
    }
}
