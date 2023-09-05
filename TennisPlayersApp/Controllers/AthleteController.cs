using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Mediator.Commands.AthleteCommands;
using TennisPlayers.Application.Mediator.Querries.AthleteQuerries;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AthleteController : Controller
    {
        private readonly IMediator _mediator;

        public AthleteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAthletes()
        {
            var result = await _mediator.Send(new GetAllAthletesQuerry());
            return result != null ? Ok(result) : NotFound("There are no athletes.");
        }

        [HttpGet("[action]/{athleteId}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteById(int athleteId)
        {
            var result = await _mediator.Send(new GetAthleteByIdQuerry(athleteId));
            return result != null ? Ok(result) : NotFound($"There is no athlete by id {athleteId}.");
        }

        [HttpGet("[action]/{lastName}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteByLastName(string lastName)
        {
            var result = await _mediator.Send(new GetAthleteByNameQuerry(lastName));
            return result != null ? Ok(result) : NotFound($"There is no athlete by last name {lastName}.");
        }

        [HttpGet("[action]/{ranking}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteByRanking(int ranking)
        {
            var result = await _mediator.Send(new GetAthleteByRankingQuerry(ranking));
            return result != null ? Ok(result) : NotFound($"There is no athlete who is rank {ranking}.");
        }

        [HttpGet("[action]/{lastName}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public IActionResult GetAthletesWinPercent(string lastName)
        {
            var result = _mediator.Send(new GetAthleteWinPercentQuerry(lastName));
            return result != null ? Ok(result) : NotFound($"There is no athlete by last name {lastName}.");
        }

        [HttpPost("AddAthelete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddAthelete([FromQuery] int countryId, [FromQuery] int coachId, [FromBody] AthleteDto athleteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateAthleteCommand(athleteDto, countryId, coachId));
            return result == true ? StatusCode(200, "Athlete added successfully.") : BadRequest("Coach or Country does not exist.");
        }

        [HttpPut("UpdateAthlete")]
        public async Task<IActionResult> UpdateAthlete(int athleteId, [FromBody] AthleteDto athleteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateAthleteCommand(athleteDto, athleteId));
            return result == true ? StatusCode(200, "Athlete updated successfully.") : BadRequest($"There is no athlete by id {athleteId}.");
        }

        [HttpDelete("DeleteAthlete")]
        public async Task<IActionResult> DeleteAthlete(int athleteId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new DeleteAthleteCommand(athleteId));
            return result == true ? StatusCode(200, "Athlete deleted successfully.") : NotFound($"There is no athlete by id {athleteId}.");
        }
    }
}
