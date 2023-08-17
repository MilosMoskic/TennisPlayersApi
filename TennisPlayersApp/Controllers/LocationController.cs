using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Services;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLocations()
        {
            var result = await _locationService.GetAllLocations();
            return Ok(result);
        }

        [HttpGet("[action]/{locationId}")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetLocationById(int locationId)
        {
            if (!_locationService.LocationExists(locationId))
                return NotFound("Location does not exist");

            var location = _locationService.GetLocationById(locationId);
            return Ok(location);
        }

        [HttpGet("[action]/{locationName}")]
        [ProducesResponseType(200, Type = typeof(Location))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetLocationByName(string locationName)
        {
            if (!_locationService.LocationExists(locationName))
                return NotFound("Location does not exist");

            var location = _locationService.GetLocationByName(locationName);
            return Ok(location);
        }

        [HttpPost("AddLocation")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddLocation([FromBody] LocationDto locationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_locationService.AddLocation(locationDto))
            {
                ModelState.AddModelError("", "Error adding new location.");
                return BadRequest(ModelState);
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
    }
}
