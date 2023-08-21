using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Services;
using TennisPlayers.Application.Validators;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : Controller
    {
        private readonly ITournamentService _tournamentService;
        private readonly ILocationService _locationService;
        public TournamentController(ITournamentService tournamentService, ILocationService locationService)
        {
            _tournamentService = tournamentService;
            _locationService = locationService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTournaments()
        {
            var result = await _tournamentService.GetAllTournaments();
            return Ok(result);
        }

        [HttpGet("[action]/{tournamentId}")]
        [ProducesResponseType(200, Type = typeof(Tournament))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTournamentById(int tournamentId)
        {
            if (!_tournamentService.TournamentExists(tournamentId))
                return NotFound("Tournament does not exist");

            var tournament = _tournamentService.GetTournamentById(tournamentId);
            return Ok(tournament);
        }

        [HttpGet("[action]/{tournamentName}")]
        [ProducesResponseType(200, Type = typeof(Tournament))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTournamentByName(string tournamentName)
        {
            if (!_tournamentService.TournamentExists(tournamentName))
                return NotFound("Tournament does not exist");

            var tournament = _tournamentService.GetTournamentByName(tournamentName);
            return Ok(tournament);
        }

        [HttpPost("AddTournament")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddTournament([FromQuery] int locationId,[FromBody] TournamentDto tournamentDto)
        {
            //var validator = new TournamentValidator();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_locationService.LocationExists(locationId))
                return NotFound("Location does not exist");

            if (!_tournamentService.AddTournament(locationId, tournamentDto))
            {
                ModelState.AddModelError("", "Error adding new tournament.");
                return BadRequest(ModelState);
            }

            //var validationResult = validator.Validate(tournamentDto);

            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult);
            //}

            return Ok("Tournament added successfully.");
        }

        [HttpPut("UpdateTournament")]
        public IActionResult UpdateTournament(int tournamentId, [FromBody] TournamentDto tournamentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_tournamentService.TournamentExists(tournamentId))
                return NotFound("Tournament does not exist.");

            if (!_tournamentService.UpdateTournament(tournamentId, tournamentDto))
                return BadRequest("Error while saving.");

            return StatusCode(200, "Successfully updated.");
        }

        [HttpDelete("DeleteTournament")]
        public async Task<IActionResult> DeleteTournament(int tournamentId)
        {
            if (!_tournamentService.TournamentExists(tournamentId))
                return NotFound("Tournament not found.");

            var tournamentToDelete = _tournamentService.GetTournamentById(tournamentId);

            if (!_tournamentService.DeleteTournament(tournamentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return BadRequest(ModelState);
            }

            return Ok("Tournament deleted successfully.");
        }
    }
}
