using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Mediator.Commands.SponsorCommands;
using TennisPlayers.Application.Mediator.Querries.SponsorQuerries;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SponsorController : Controller
    {
        private readonly IMediator _mediator;
        public SponsorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSponsors()
        {
            var result = await _mediator.Send(new GetAllSponsorsQuerry());
            return result != null ? Ok(result) : NotFound("There are no sponsors.");
        }

        [HttpGet("[action]/{sponsorId}")]
        [ProducesResponseType(200, Type = typeof(Sponsor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSponsorById(int sponsorId)
        {
            var result = await _mediator.Send(new GetSponsorByIdQuerry(sponsorId));
            return result != null ? Ok(result) : NotFound($"There is no sponsor by id {sponsorId}.");
        }

        [HttpGet("[action]/{sponsorName}")]
        [ProducesResponseType(200, Type = typeof(Sponsor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSponsorByName(string sponsorName)
        {
            var result = await _mediator.Send(new GetSponsorByNameQuerry(sponsorName));
            return result != null ? Ok(result) : NotFound($"There is no sponsor by last name {sponsorName}.");
        }

        [HttpGet("[action]/{netWorth}")]
        [ProducesResponseType(200, Type = typeof(Sponsor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSponsorByNW(decimal netWorth)
        {
            var result = await _mediator.Send(new GetSponsorsByNWQuerry(netWorth));
            return result != null ? Ok(result) : NotFound($"There are no sponsor with net worth higher than {netWorth}.");
        }

        [HttpPost("AddSponsor")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddSponsor([FromBody] SponsorDto sponsorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateSponsorCommand(sponsorDto));
            return result == true ? StatusCode(200, "Sponsor added successfully.") : BadRequest("Sponsor is not added successfully.");
        }

        [HttpPut("UpdateSponsor")]
        public async Task<IActionResult> UpdateSponsor(int sponsorId, [FromBody] SponsorDto sponsorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateSponsorCommand(sponsorDto, sponsorId));
            return result == true ? StatusCode(200, "Sponsor updated successfully.") : BadRequest($"There is no sponsor by id {sponsorId}.");
        }

        [HttpDelete("DeleteSponsor")]
        public async Task<IActionResult> DeleteSponsor(int sponsorId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);  

            var result = await _mediator.Send(new DeleteSponsorCommand(sponsorId));
            return result == true ? StatusCode(200, "Sponsor deleted successfully.") : NotFound($"There is no sponsor by id {sponsorId}.");
        }
    }
}
