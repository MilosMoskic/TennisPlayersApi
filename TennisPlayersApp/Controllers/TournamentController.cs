using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Mediator.Commands.TournamentCommands;
using TennisPlayers.Application.Mediator.Querries.TournamentQuerries;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : Controller
    {
        private readonly IMediator _mediator;
        public TournamentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTournaments()
        {
            var result = await _mediator.Send(new GetAllTournamentsQuerry());
            return result != null ? Ok(result) : NotFound("There are no tournaments.");
        }

        [HttpGet("[action]/{tournamentId}")]
        [ProducesResponseType(200, Type = typeof(Tournament))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTournamentById(int tournamentId)
        {
            var result = await _mediator.Send(new GetTournamentByIdQuerry(tournamentId));
            return result != null ? Ok(result) : NotFound($"There is no tournament by id {tournamentId}.");
        }

        [HttpGet("[action]/{tournamentName}")]
        [ProducesResponseType(200, Type = typeof(Tournament))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTournamentByName(string tournamentName)
        {
            var result = await _mediator.Send(new GetTournamentByNameQuerry(tournamentName));
            return result != null ? Ok(result) : NotFound($"There is no tournament by name {tournamentName}.");
        }

        [HttpPost("AddTournament")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddTournament([FromQuery] int locationId,[FromBody] TournamentDto tournamentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateTournamentCommand(tournamentDto, locationId));
            return result == true ? StatusCode(200, "Tournament added successfully.") : BadRequest("Tournament is not added successfully.");
        }

        [HttpPut("UpdateTournament")]
        public async Task<IActionResult> UpdateTournament(int tournamentId, [FromBody] TournamentDto tournamentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateTournamentCommand(tournamentId, tournamentDto));
            return result == true ? StatusCode(200, "Tournament updated successfully.") : BadRequest("Tournament is not updated successfully.");
        }

        [HttpDelete("DeleteTournament")]
        public async Task<IActionResult> DeleteTournament(int tournamentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new DeleteTournamentCommand(tournamentId));
            return result == true ? StatusCode(200, "Tournament deleted successfully.") : NotFound($"There is no tournament by id {tournamentId}.");
        }
    }
}
