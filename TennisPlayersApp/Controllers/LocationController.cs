using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Mediator.Commands.LocationCommands;
using TennisPlayers.Application.Mediator.Querries.LocationQuerries;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLocations()
        {
            var result = await _mediator.Send(new GetAllLocationsQuerry());
            return result != null ? Ok(result) : NotFound("There are no locations.");
        }

        [HttpGet("[action]/{locationId}")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetLocationById(int locationId)
        {
            var result = await _mediator.Send(new GetLocationByIdQuerry(locationId));
            return result != null ? Ok(result) : NotFound($"There is no location by id {locationId}");
        }

        [HttpGet("[action]/{locationName}")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetLocationByName(string locationName)
        {
            var result = await _mediator.Send(new GetLocationByNameQuerry(locationName));
            return result != null ? Ok(result) : NotFound($"There is no location by name {locationName}");
        }

        [HttpPost("AddLocation")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddLocation([FromBody] LocationDto locationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateLocationCommand(locationDto));
            return result == true ? StatusCode(200, "Location added successfully.") : BadRequest("Location is not added successfully.");
        }

        [HttpPut("UpdateLocation")]
        public async Task<IActionResult> UpdateLocation(int locationId, [FromBody] LocationDto locationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateLocationCommand(locationDto, locationId));
            return result == true ? StatusCode(200, "Location updated successfully.") : BadRequest($"There is no location by id {locationId}");
        }

        [HttpDelete("DeleteLocation")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new DeleteLocationCommand(locationId));
            return result == true ? StatusCode(200, "Location deleted successfully.") : NotFound($"There is no location by id {locationId}");
        }
    }
}
