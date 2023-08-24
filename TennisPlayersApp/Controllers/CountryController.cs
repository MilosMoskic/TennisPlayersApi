using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Querries.CountryQuerries;
using TennisPlayers.Application.Services;
using TennisPlayers.Application.Validators;
using TennisPlayers.Domain.Models;
using TennisPlayers.Domain.Validators;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        public readonly IMediator _mediator;
        public readonly ICountryService _countryService;
        public CountryController(IMediator mediator, ICountryService countryService)
        {
            _mediator = mediator;
            _countryService = countryService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCountries()
        {
            var result = await _mediator.Send(new GetAllCountriesQuerry());
            return Ok(result);
        }

        [HttpGet("[action]/{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCountryById(int countryId)
        {
            var result = await _mediator.Send(new GetCountryByIdQuerry(countryId));
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("[action]/{countryName}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCountryByCountryName(string countryName)
        {
            var result = await _mediator.Send(new GetCountryByNameQuerry(countryName));
            return result != null ? Ok(result) : NotFound();
        }


        [HttpPost("AddCountry")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddCountry([FromBody] CountryDto countryDto)
        {
            var validator = new CountryValidator();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_countryService.AddCountry(countryDto))
            {
                ModelState.AddModelError("", "Error adding new country.");
                return BadRequest(ModelState);
            }

            var validationResult = validator.Validate(countryDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
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
