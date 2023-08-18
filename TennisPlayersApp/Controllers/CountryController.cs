using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Services;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        public readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCountries()
        {
            var result = await _countryService.GetAllCountries();
            return Ok(result);
        }

        [HttpGet("[action]/{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCountryById(int countryId)
        {
            if (!_countryService.CountryExists(countryId))
                return NotFound("Country does not exist");

            var country = _countryService.GetCountryById(countryId);
            return Ok(country);
        }

        [HttpGet("[action]/{countryName}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCountryByCountryName(string countryName)
        {
            if (!_countryService.CountryExists(countryName))
                return NotFound("Country does not exist");

            var country = _countryService.GetCountryByName(countryName);
            return Ok(country);
        }


        [HttpPost("AddCountry")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddCountry([FromBody] CountryDto countryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_countryService.AddCountry(countryDto))
            {
                ModelState.AddModelError("", "Error adding new country.");
                return BadRequest(ModelState);
            }

            return Ok("Country added successfully.");
        }

        [HttpPut("UpdateCountry")]
        public IActionResult UpdateCountry(int countryId, [FromBody] CountryDto countryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_countryService.CountryExists(countryId))
                return NotFound("Country does not exist.");

            if (!_countryService.UpdateCountry(countryId, countryDto))
                return BadRequest("Error while saving.");

            return StatusCode(200, "Successfully updated.");
        }

        [HttpDelete("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(int countryId)
        {
            if (!_countryService.CountryExists(countryId))
                return NotFound("Country not found.");

            var countryToDelete = _countryService.GetCountryById(countryId);

            if (!_countryService.DeleteCountry(countryToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return BadRequest(ModelState);
            }

            return Ok("Country deleted successfully.");
        }
    }
}
