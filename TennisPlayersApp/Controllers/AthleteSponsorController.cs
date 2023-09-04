using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Mediator.Commands.AthleteSponsorCommands;
using TennisPlayers.Application.Mediator.Querries.AthleteSponsorQuerries;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AthleteSponsorController : Controller
    {
        private readonly IMediator _mediator;
        public AthleteSponsorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{athleteId}")]
        public async Task<IActionResult> GetSponsorsOfAthleteQuerry(int athleteId)
        {
            var result = await _mediator.Send(new GetSponsorsOfAthleteQuerry(athleteId));
            return result != null ? Ok(result) : NotFound("Sponsor does not exist.");
        }

        [HttpGet("[action]/{sponsorId}")]
        public async Task<IActionResult> GetAthletesBySponsorQuerry(int sponsorId)
        {
            var result = await _mediator.Send(new GetAthletesBySponsorQuerry(sponsorId));
            return result != null ? Ok(result) : NotFound("Athlete does not exist.");
        }

        [HttpPost("AddSponsorToAthlete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddSponsorToAthlete(int sponsorId, int athleteId, AthleteSponsorDto athleteSponsorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new AddSponsorToAthleteCommand(sponsorId, athleteId, athleteSponsorDto));
            return result != null ? Ok(result) : NotFound("Sponsor does not exist.");
        }

        [HttpDelete("RemoveSponsorFromAthlete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveSponsorFromAthlete(int athleteId, int sponsorId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new RemoveSponsorFromAthleteCommand(athleteId, sponsorId));
            return result != null ? Ok(result) : NotFound("Athlete does not exist.");
        }
    }
}
