using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Mediator.Commands.CoachCommands;
using TennisPlayers.Application.Mediator.Querries.CoachQuerries;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoachController : Controller
    {
        private readonly IMediator _mediator;

        public CoachController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCoaches()
        {
            var result = await _mediator.Send(new GetAllCoachesQuerry());
            return result != null ? Ok(result) : NotFound("There are no coaches.");
        }

        [HttpGet("[action]/{coachId}")]
        [ProducesResponseType(200, Type = typeof(Coach))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCoachById(int coachId)
        {
            var result = await _mediator.Send(new GetCoachByIdQuerry(coachId));
            return result != null ? Ok(result) : NotFound($"There is no coach by id {coachId}");
        }

        [HttpGet("[action]/{lastName}")]
        [ProducesResponseType(200, Type = typeof(Coach))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCoachByLastName(string lastName)
        {
            var result = await _mediator.Send(new GetCoachesByLastNameQuerry(lastName));
            return result != null ? Ok(result) : NotFound($"There is no coach by last name {lastName}");
        }

        [HttpPost("AddCoach")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddCoach([FromBody] CoachDto coachDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateCoachCommand(coachDto));
            return result == true ? StatusCode(200, "Coach added successfully.") : BadRequest("Coach is not added successfully.");
        }

        [HttpPut("UpdateCoach")]
        public async Task<IActionResult> UpdateCoach(int coachId, [FromBody] CoachDto coachDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateCoachCommand(coachDto, coachId));
            return result == true ? StatusCode(200, "Coach updated successfully.") : BadRequest("Coach does not exist.");
        }

        [HttpDelete("DeleteCoach")]
        public async Task<IActionResult> DeleteCoach(int coachId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new DeleteCoachCommand(coachId));
            return result == true ? StatusCode(200, "Coach deleted successfully.") : NotFound("Coach does not exist.");
        }
    }
}
