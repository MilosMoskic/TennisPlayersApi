using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Mediator.Commands.AthleteTournamentCommands;
using TennisPlayers.Application.Mediator.Querries.AthleteTournamentQuerries;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AthleteTournamentController : Controller
    {
        private readonly IMediator _mediator;
        public AthleteTournamentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]/{tournamentId}")]
        public async Task<IActionResult> GetAthletesByTournament(int tournamentId)
        {
            var result = await _mediator.Send(new GetAthletesByTournamentQuerry(tournamentId));
            return result != null ? Ok(result) : NotFound($"There are no athletes in tournament by id {tournamentId}.");
        }

        [HttpPost("AddAtheleteToTournament")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddAthleteToTournament(int athleteId, int tournamentId, AthleteTournamentDto athleteTournamentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new AddAthleteToTournamentCommand(athleteId, tournamentId, athleteTournamentDto));
            return result != null ? Ok(result) : NotFound("Tournament or athlete does not exist.");
        }

        [HttpDelete("RemoveAthleteFromTournament")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveAthleteFromTournament(int athleteId, int tournamentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new RemoveAthleteFromTournamentCommand(athleteId, tournamentId));
            return result != null ? Ok(result) : NotFound("Tournament or athlete does not exist.");
        }
    }
}
