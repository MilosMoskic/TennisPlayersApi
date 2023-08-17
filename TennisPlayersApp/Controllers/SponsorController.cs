using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Services;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SponsorController : Controller
    {
        public readonly ISponsorService _sponsorService;
        public readonly IAthleteService _athleteService;
        public SponsorController(ISponsorService sponsorService, IAthleteService athleteService)
        {
            _sponsorService = sponsorService;
            _athleteService = athleteService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSponsors()
        {
            var result = await _sponsorService.GetAllSponsors();
            return Ok(result);
        }

        [HttpGet("[action]/{sponsorId}")]
        [ProducesResponseType(200, Type = typeof(Sponsor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSponsorById(int sponsorId)
        {
            if (!_sponsorService.SponsorExists(sponsorId))
                return NotFound("Sponsor does not exist");

            var sponsor = _sponsorService.GetSponsorById(sponsorId);
            return Ok(sponsor);
        }

        [HttpGet("[action]/{sponsorName}")]
        [ProducesResponseType(200, Type = typeof(Sponsor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSponsorByName(string sponsorName)
        {
            if (!_sponsorService.SponsorExists(sponsorName))
                return NotFound("Sponsor does not exist");

            var sponsor = _sponsorService.GetSponsorByName(sponsorName);
            return Ok(sponsor);
        }

        [HttpGet("[action]/{netWorth}")]
        [ProducesResponseType(200, Type = typeof(Sponsor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSponsorByNW(decimal netWorth)
        {
            var sponsor = await _sponsorService.GetSponsorsByNW(netWorth);
            return Ok(sponsor);
        }

        [HttpPost("AddSponsor")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddSponsor([FromBody] SponsorDto sponsorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_sponsorService.AddSponsor(sponsorDto))
            {
                ModelState.AddModelError("", "Error adding new sponsor.");
                return BadRequest(ModelState);
            }

            return Ok("Sponsor added successfully.");
        }

        [HttpPost("AddSponsorToAthlete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddSponsorToAthlete([FromQuery] int athleteId, int sponsorId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_athleteService.AthleteExists(athleteId))
                return NotFound("Athlete does not exist");

            if (!_sponsorService.SponsorExists(sponsorId))
                return NotFound("Sponsor does not exist");

            if (!_sponsorService.AddSponsorToAthlete(athleteId, sponsorId))
            {
                ModelState.AddModelError("", "Error adding thlete to sponsor.");
                return BadRequest(ModelState);
            }

            return Ok("Successfully added Sponsor to Athlete.");
        }

        [HttpPut("UpdateSponsor")]
        public IActionResult UpdateSponsor(int sponsorId, [FromBody] SponsorDto sponsorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_sponsorService.SponsorExists(sponsorId))
                return NotFound("Sponsor does not exist.");

            if (!_sponsorService.UpdateSponsor(sponsorId, sponsorDto))
                return BadRequest("Error while saving.");

            return StatusCode(200, "Successfully updated.");
        }
    }
}
