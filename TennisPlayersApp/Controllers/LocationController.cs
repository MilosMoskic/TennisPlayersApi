using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
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
        public IActionResult AddLocation([FromBody] LocationDto locationDto)
        {
            var validator = new LocationValidator();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_locationService.AddLocation(locationDto))
            {
                ModelState.AddModelError("", "Error adding new location.");
                return BadRequest(ModelState);
            }

            var validationResult = validator.Validate(locationDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            return Ok("Location added successfully.");
        }

        [HttpPut("UpdateLocation")]
        public IActionResult UpdateLocation(int locationId, [FromBody] LocationDto locationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_locationService.LocationExists(locationId))
                return NotFound("Location does not exist.");

            if (!_locationService.UpdateLocation(locationId, locationDto))
                return BadRequest("Error while saving.");

            return StatusCode(200, "Successfully updated.");
        }

        [HttpDelete("DeleteLocation")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            if (!_locationService.LocationExists(locationId))
                return NotFound("Location not found.");

            var locationToDelete = _locationService.GetLocationById(locationId);

            if (!_locationService.DeleteLocation(locationToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return BadRequest(ModelState);
            }

            return Ok("Location deleted successfully.");
        }
    }
}
