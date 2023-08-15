using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Services;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentController : Controller
    {
        private readonly ITournamentService _tournamentService;
        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
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

            var coach = _tournamentService.GetTournamentById(tournamentId);
            return Ok(coach);
        }

        [HttpGet("[action]/{tournamentName}")]
        [ProducesResponseType(200, Type = typeof(Tournament))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTournamentByName(string tournamentName)
        {
            if (!_tournamentService.TournamentExists(tournamentName))
                return NotFound("Tournament does not exist");

            var coach = _tournamentService.GetTournamentByName(tournamentName);
            return Ok(coach);
        }
    }
}
