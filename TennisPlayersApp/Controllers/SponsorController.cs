using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Handlers.CoachHandlers;
using TennisPlayers.Application.Mediator.Handlers.SponsorHandlers;
using TennisPlayers.Application.Mediator.Querries.SponsorQuerries;
using TennisPlayers.Application.Services;
using TennisPlayers.Application.Validators;
using TennisPlayers.Domain.Models;
using TennisPlayers.Domain.Validators;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SponsorController : Controller
    {
        private readonly IMediator _mediator;
        public readonly ISponsorService _sponsorService;
        public readonly IAthleteService _athleteService;
        public SponsorController(IMediator mediator, ISponsorService sponsorService, IAthleteService athleteService)
        {
            _mediator = mediator;
            _sponsorService = sponsorService;
            _athleteService = athleteService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSponsors()
        {
            var result = await _mediator.Send(new GetAllSponsorsQuerry());
            return Ok(result);
        }

        [HttpGet("[action]/{sponsorId}")]
        [ProducesResponseType(200, Type = typeof(Sponsor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSponsorById(int sponsorId)
        {
            var result = await _mediator.Send(new GetSponsorByIdQuerry(sponsorId));
            return result != null ? Ok(result) : NotFound("Sponsor does not exist.");
        }

        [HttpGet("[action]/{sponsorName}")]
        [ProducesResponseType(200, Type = typeof(Sponsor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSponsorByName(string sponsorName)
        {
            var result = await _mediator.Send(new GetSponsorByNameQuerry(sponsorName));
            return result != null ? Ok(result) : NotFound("Sponsor does not exist.");
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
            var validator = new SponsorValidator();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_sponsorService.AddSponsor(sponsorDto))
            {
                ModelState.AddModelError("", "Error adding new sponsor.");
                return BadRequest(ModelState);
            }

            var validationResult = validator.Validate(sponsorDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
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

        [HttpDelete("DeleteSponsor")]
        public async Task<IActionResult> DeleteSponsor(int sponsorId)
        {
            if (!_sponsorService.SponsorExists(sponsorId))
                return NotFound("Sponsor not found.");

            var sponsorToDelete = _sponsorService.GetSponsorById(sponsorId);

            if (!_sponsorService.DeleteSponsor(sponsorToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return BadRequest(ModelState);
            }

            return Ok("Sponsor deleted successfully.");
        }
    }
}
