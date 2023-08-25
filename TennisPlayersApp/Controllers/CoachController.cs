using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.CoachCommands;
using TennisPlayers.Application.Mediator.Querries.CoachQuerries;
using TennisPlayers.Application.Services;
using TennisPlayers.Domain.Models;
using TennisPlayers.Domain.Validators;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoachController : Controller
    {
        private readonly ICoachService _coachService;
        private readonly IMediator _mediator;

        public CoachController(IMediator mediator, ICoachService coachService)
        {
            _mediator = mediator;
            _coachService = coachService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCoaches()
        {
            var result = await _mediator.Send(new GetAllCoachesQuerry());
            return Ok(result);
        }

        [HttpGet("[action]/{coachId}")]
        [ProducesResponseType(200, Type = typeof(Coach))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCoachById(int coachId)
        {
            var result = await _mediator.Send(new GetCoachByIdQuerry(coachId));
            return result != null ? Ok(result) : NotFound("Coach does not exist.");
        }

        [HttpGet("[action]/{lastName}")]
        [ProducesResponseType(200, Type = typeof(Coach))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCoachByLastName(string lastName)
        {
            var result = await _mediator.Send(new GetCoachesByLastNameQuerry(lastName));
            return result != null ? Ok(result) : NotFound("Coach does not exist.");
        }

        [HttpPost("AddCoach")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddCoach([FromBody] CoachDto coachDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateCoachCommand(coachDto));
            return result == true ? StatusCode(200, "Coach added successfully.") : BadRequest(ModelState);
        }

        [HttpPut("UpdateCoach")]
        public IActionResult UpdateCoach(int coachId, [FromBody] CoachDto coachDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_coachService.CoachExists(coachId))
                return NotFound("Coach does not exist.");

            if (!_coachService.UpdateCoach(coachId, coachDto))
                return BadRequest("Error while saving.");

            return StatusCode(200, "Successfully updated.");
        }

        [HttpDelete("DeleteCoach")]
        public async Task<IActionResult> DeleteCoach(int coachId)
        {
            if (!_coachService.CoachExists(coachId))
                return NotFound("Coach not found.");

            var coachToDelete = _coachService.GetCoachById(coachId);

            if (!_coachService.DeleteCoach(coachToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return BadRequest(ModelState);
            }

            return Ok("Coach deleted successfully.");
        }
    }
}
