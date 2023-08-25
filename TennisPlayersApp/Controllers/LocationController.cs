using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.CoachCommands;
using TennisPlayers.Application.Mediator.Commands.LocationCommands;
using TennisPlayers.Application.Mediator.Querries.LocationQuerries;
using TennisPlayers.Application.Validators;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator, ILocationService locationService)
        {
            _mediator = mediator;
            _locationService = locationService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLocations()
        {
            var result = await _mediator.Send(new GetAllLocationsQuerry());
            return Ok(result);
        }

        [HttpGet("[action]/{locationId}")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetLocationById(int locationId)
        {
            var result = await _mediator.Send(new GetLocationByIdQuerry(locationId));
            return result != null ? Ok(result) : NotFound("Location does not exist.");
        }

        [HttpGet("[action]/{locationName}")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetLocationByName(string locationName)
        {
            var result = await _mediator.Send(new GetLocationByNameQuerry(locationName));
            return result != null ? Ok(result) : NotFound("Location does not exist.");
        }

        [HttpPost("AddLocation")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddLocation([FromBody] LocationDto locationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateLocationCommand(locationDto));
            return result == true ? StatusCode(200, "Location added successfully.") : BadRequest(ModelState);
        }

        [HttpPut("UpdateLocation")]
        public async Task<IActionResult> UpdateLocation(int locationId, [FromBody] LocationDto locationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateLocationCommand(locationDto, locationId));
            return result == true ? StatusCode(200, "Location updated successfully.") : BadRequest(ModelState);
        }

        [HttpDelete("DeleteLocation")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new DeleteLocationCommand(locationId));
            return result == true ? StatusCode(200, "Location deleted successfully.") : NotFound("Location does not exist.");
        }
    }
}
