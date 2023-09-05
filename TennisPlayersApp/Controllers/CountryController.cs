using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Mediator.Commands.CountryCommands;
using TennisPlayers.Application.Mediator.Querries.CountryQuerries;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        public readonly IMediator _mediator;
        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCountries()
        {
            var result = await _mediator.Send(new GetAllCountriesQuerry());
            return result != null ? Ok(result) : NotFound("There are no countries.");
        }

        [HttpGet("[action]/{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCountryById(int countryId)
        {
            var result = await _mediator.Send(new GetCountryByIdQuerry(countryId));
            return result != null ? Ok(result) : NotFound($"There is no country by id {countryId}.");
        }

        [HttpGet("[action]/{countryName}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCountryByCountryName(string countryName)
        {
            var result = await _mediator.Send(new GetCountryByNameQuerry(countryName));
            return result != null ? Ok(result) : NotFound($"There is no country with name {countryName}.");
        }


        [HttpPost("AddCountry")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddCountry([FromBody] CountryDto countryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateCountryCommand(countryDto));
            return result == true ? StatusCode(200, "Country added successfully.") : BadRequest("Country is not added successfully.");
        }

        [HttpPut("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry(int countryId, [FromBody] CountryDto countryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateCountryCommand(countryId, countryDto));
            return result == true ? StatusCode(200, "Country updated successfully.") : BadRequest($"There is no country by id {countryId}.");
        }

        [HttpDelete("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(int countryId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new DeleteCountryCommand(countryId));
            return result == true ? StatusCode(200, "Country deleted successfully.") : NotFound($"There is no country by id {countryId}.");
        }
    }
}
