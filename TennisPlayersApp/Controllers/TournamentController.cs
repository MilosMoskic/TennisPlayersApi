using MediatR;
using Microsoft.AspNetCore.Mvc;using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
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
        private readonly ITournamentService _tournamentService;
        private readonly ILocationService _locationService;
        public TournamentController(IMediator mediator, ITournamentService tournamentService, ILocationService locationService)
        {
            _mediator = mediator;
            _tournamentService = tournamentService;
            _locationService = locationService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTournaments()
        {
            var result = await _mediator.Send(new GetAllTournamentsQuerry());
            return Ok(result);
        }

        [HttpGet("[action]/{tournamentId}")]
        [ProducesResponseType(200, Type = typeof(Tournament))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTournamentById(int tournamentId)
        {
            var result = await _mediator.Send(new GetTournamentByIdQuerry(tournamentId));
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("[action]/{tournamentName}")]
        [ProducesResponseType(200, Type = typeof(Tournament))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTournamentByName(string tournamentName)
        {
            var result = await _mediator.Send(new GetTournamentByNameQuerry(tournamentName));
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost("AddTournament")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddTournament([FromQuery] int locationId,[FromBody] TournamentDto tournamentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateTournamentCommand(tournamentDto, locationId));
            return result == true ? StatusCode(200, "Tournament added successfully.") : BadRequest(ModelState);
        }

        [HttpPut("UpdateTournament")]
        public async Task<IActionResult> UpdateTournament(int tournamentId, [FromBody] TournamentDto tournamentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateTournamentCommand(tournamentId, tournamentDto));
            return result == true ? StatusCode(200, "Tournament updated successfully.") : BadRequest(ModelState);
        }

        [HttpDelete("DeleteTournament")]
        public async Task<IActionResult> DeleteTournament(int tournamentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new DeleteTournamentCommand(tournamentId));
            return result == true ? StatusCode(200, "Tournament deleted successfully.") : NotFound("Tournament does not exist.");
        }
    }
}
