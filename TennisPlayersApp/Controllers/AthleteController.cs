using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AthleteController : Controller
    {
        private readonly IAthleteService _athleteService;
        private readonly ITournamentService _tournamentService;

        public AthleteController(IAthleteService athleteService, ITournamentService tournamentService)
        {
            _athleteService = athleteService;
            _tournamentService = tournamentService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAthletes()
        {
            var result = await _athleteService.GetAllAthletes();
            return Ok(result);
        }

        [HttpGet("[action]/{athleteId}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteById(int athleteId)
        {
            if (!_athleteService.AthleteExists(athleteId))
                return NotFound("Athlete does not exist");

            var coach = _athleteService.GetAthleteById(athleteId);
            return Ok(coach);
        }

        [HttpGet("[action]/{lastName}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteByLastName(string lastName)
        {
            if (!_athleteService.AthleteExists(lastName))
                return NotFound("Athlete does not exist");

            var coach = _athleteService.GetAthleteByName(lastName);
            return Ok(coach);
        }

        [HttpGet("[action]/{ranking}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteByRanking(int ranking)
        {
            if (!_athleteService.AthleteExists(ranking))
                return NotFound("Athlete does not exist");

            var coach = _athleteService.GetAthleteByRanking(ranking);
            return Ok(coach);
        }

        [HttpGet("[action]/{tournamentId}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteByTournament(int tournamentId)
        {
            if (!_tournamentService.TournamentExists(tournamentId))
                return NotFound("Tournament does not exist");

            var coach = _athleteService.GetAthletesByTournament(tournamentId);
            return Ok(coach);
        }

        [HttpGet("[action]/{lastName}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public IActionResult GetAthletesWinPercent(string lastname)
        {
            if (!_athleteService.AthleteExists(lastname))
                return NotFound("Athlete does not exist");

            var coach = _athleteService.GetAthleteWinPercent(lastname);
            return Ok(coach);
        }
    }
}
