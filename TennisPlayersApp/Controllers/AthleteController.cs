﻿using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Services;
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
        private readonly ISponsorService _sponsorService;

        public AthleteController(IAthleteService athleteService, ITournamentService tournamentService, ISponsorService sponsorService)
        {
            _athleteService = athleteService;
            _tournamentService = tournamentService;
            _sponsorService = sponsorService;
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

            var athlete = _athleteService.GetAthleteById(athleteId);
            return Ok(athlete);
        }

        [HttpGet("[action]/{lastName}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteByLastName(string lastName)
        {
            if (!_athleteService.AthleteExists(lastName))
                return NotFound("Athlete does not exist");

            var athlete = _athleteService.GetAthleteByName(lastName);
            return Ok(athlete);
        }

        [HttpGet("[action]/{ranking}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteByRanking(int ranking)
        {
            if (!_athleteService.AthleteExists(ranking))
                return NotFound("Athlete does not exist");

            var athlete = _athleteService.GetAthleteByRanking(ranking);
            return Ok(athlete);
        }

        [HttpGet("[action]/{tournamentId}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteByTournament(int tournamentId)
        {
            if (!_tournamentService.TournamentExists(tournamentId))
                return NotFound("Tournament does not exist");

            var athlete = _athleteService.GetAthletesByTournament(tournamentId);
            return Ok(athlete);
        }

        [HttpGet("[action]/{sponsorId}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteBySponsor(int sponsorId)
        {
            if (!_sponsorService.SponsorExists(sponsorId))
                return NotFound("Sponsor does not exist");

            var athlete = _athleteService.GetAthletesBySponsor(sponsorId);
            return Ok(athlete);
        }

        [HttpGet("[action]/{lastName}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public IActionResult GetAthletesWinPercent(string lastName)
        {
            if (!_athleteService.AthleteExists(lastName))
                return NotFound("Athlete does not exist");

            var athlete = _athleteService.GetAthleteWinPercent(lastName);
            return Ok(athlete);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddAthelete([FromQuery] int countryId, [FromQuery] int coachId, [FromBody] AthleteDto athleteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_athleteService.AddAthlete(coachId, countryId, athleteDto))
            {
                ModelState.AddModelError("", "Error adding new athlete.");
                return BadRequest(ModelState);
            }

            return Ok("Athlete added successfully.");
        }
    }
}
