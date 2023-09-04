using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.AthleteSponsorCommands;
using TennisPlayers.Application.Mediator.Commands.CoachCommands;
using TennisPlayers.Application.Mediator.Commands.LocationCommands;
using TennisPlayers.Application.Mediator.Commands.SponsorCommands;
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
        public async Task<IActionResult> AddSponsor([FromBody] SponsorDto sponsorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateSponsorCommand(sponsorDto));
            return result == true ? StatusCode(200, "Sponsor added successfully.") : BadRequest(ModelState);
        }

        [HttpPut("UpdateSponsor")]
        public async Task<IActionResult> UpdateSponsor(int sponsorId, [FromBody] SponsorDto sponsorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateSponsorCommand(sponsorDto, sponsorId));
            return result == true ? StatusCode(200, "Sponsor updated successfully.") : BadRequest(ModelState);
        }

        [HttpDelete("DeleteSponsor")]
        public async Task<IActionResult> DeleteSponsor(int sponsorId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);  

            var result = await _mediator.Send(new DeleteSponsorCommand(sponsorId));
            return result == true ? StatusCode(200, "Sponsor deleted successfully.") : NotFound("Sponsor does not exist.");
        }
    }
}
