using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
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
        private readonly IAthleteService _athleteService;
        private readonly ITournamentService _tournamentService;
        private readonly ISponsorService _sponsorService;
        private readonly ICoachService _coachService;
        private readonly ICountryService _countryService;

        public AthleteController(IMediator mediator,
            IAthleteService athleteService,
            ITournamentService tournamentService,
            ICoachService coachService,
            ICountryService countryService,
            ISponsorService sponsorService)
        {
            _mediator = mediator;
            _athleteService = athleteService;
            _tournamentService = tournamentService;
            _coachService = coachService;
            _countryService = countryService;
            _sponsorService = sponsorService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAthletes()
        {
            var result = await _mediator.Send(new GetAllAthletesQuerry());
            return result != null ? Ok(result) : NotFound("Athlete does not exist.");
        }

        [HttpGet("[action]/{athleteId}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteById(int athleteId)
        {
            var result = await _mediator.Send(new GetAthleteByIdQuerry(athleteId));
            return result != null ? Ok(result) : NotFound("Athlete does not exist.");
        }

        [HttpGet("[action]/{lastName}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteByLastName(string lastName)
        {
            var result = await _mediator.Send(new GetAthleteByNameQuerry(lastName));
            return result != null ? Ok(result) : NotFound("Athlete does not exist.");
        }

        [HttpGet("[action]/{ranking}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteByRanking(int ranking)
        {
            var result = await _mediator.Send(new GetAthleteByRankingQuerry(ranking));
            return result != null ? Ok(result) : NotFound("Athlete does not exist.");
        }

        [HttpGet("[action]/{sponsorId}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAthleteBySponsor(int sponsorId)
        {
            var result = await _mediator.Send(new GetAthletesBySponsorQuerry(sponsorId));
            return result != null ? Ok(result) : NotFound("Athlete does not exist.");
        }

        [HttpGet("[action]/{lastName}")]
        [ProducesResponseType(200, Type = typeof(Athlete))]
        [ProducesResponseType(400)]
        public IActionResult GetAthletesWinPercent(string lastName)
        {
            var result = _mediator.Send(new GetAthleteWinPercentQuerry(lastName));
            return result != null ? Ok(result) : NotFound("Athlete does not exist.");
        }

        [HttpPost("AddAthelete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddAthelete([FromQuery] int countryId, [FromQuery] int coachId, [FromBody] AthleteDto athleteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateAthleteCommand(athleteDto, countryId, coachId));
            return result == true ? StatusCode(200, "Athlete added successfully.") : BadRequest(ModelState);
        }

        //[HttpPost("AddAtheleteToTournament")]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(400)]
        //public IActionResult AddAthleteToTournament([FromQuery] int athleteId, [FromQuery] int tournamentId)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    if (!_athleteService.AthleteExists(athleteId))
        //        return NotFound("Athlete does not exist");

        //    if (!_tournamentService.TournamentExists(tournamentId))
        //        return NotFound("Tournament does not exist");

        //    if (!_athleteService.AddAthleteToTournament(athleteId, tournamentId))
        //    {
        //        ModelState.AddModelError("", "Error adding athlete to tournament.");
        //        return BadRequest(ModelState);
        //    }

        //    return Ok("Successfully added Athlete to a Tournament.");
        //}

        [HttpPut("UpdateAthlete")]
        public async Task<IActionResult> UpdateAthlete(int athleteId, [FromBody] AthleteDto athleteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateAthleteCommand(athleteDto, athleteId));
            return result == true ? StatusCode(200, "Athlete updated successfully.") : BadRequest(ModelState);
        }

        [HttpDelete("DeleteAthlete")]
        public async Task<IActionResult> DeleteAthlete(int athleteId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new DeleteAthleteCommand(athleteId));
            return result == true ? StatusCode(200, "Athlete deleted successfully.") : NotFound("Athlete does not exist.");
        }

        //[HttpDelete("RemoveAthleteFromTournament")]
        //public async Task<IActionResult> RemoveAthleteFromTournament(int athleteId, int tournamentId)
        //{
        //    if (!_athleteService.AthleteExists(athleteId))
        //        return NotFound("Athlete not found.");

        //    if (!_tournamentService.TournamentExists(tournamentId))
        //        return NotFound("Tournament not found.");

        //    if (!_athleteService.RemoveAthleteFromTournament(athleteId, tournamentId))
        //    {
        //        ModelState.AddModelError("", "Something went wrong while saving.");
        //        return BadRequest(ModelState);
        //    }

        //    return Ok("Athlete removed successfully.");
        //}

        //[HttpDelete("RemoveAthleteFromSponsor")]
        //public async Task<IActionResult> RemoveAthleteFromSponsor(int athleteId, int sponsorId)
        //{
        //    if (!_athleteService.AthleteExists(athleteId))
        //        return NotFound("Athlete not found.");

        //    if (!_sponsorService.SponsorExists(sponsorId))
        //        return NotFound("Sponsor not found.");

        //    if (!_athleteService.RemoveAthleteFromSponsor(athleteId, sponsorId))
        //    {
        //        ModelState.AddModelError("", "Something went wrong while saving.");
        //        return BadRequest(ModelState);
        //    }

        //    return Ok("Athlete removed successfully.");
        //}
    }
}
