using MediatR;
using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Commands.CountryCommands;
using TennisPlayers.Application.Mediator.Commands.LocationCommands;
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
        public async Task<IActionResult> AddCountry([FromBody] CountryDto countryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateCountryCommand(countryDto));
            return result == true ? StatusCode(200, "Country added successfully.") : BadRequest(ModelState);
        }

        [HttpPut("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry(int countryId, [FromBody] CountryDto countryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateCountryCommand(countryId, countryDto));
            return result == true ? StatusCode(200, "Country updated successfully.") : BadRequest(ModelState);
        }

        [HttpDelete("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(int countryId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new DeleteCountryCommand(countryId));
            return result == true ? StatusCode(200, "Country deleted successfully.") : NotFound("Country does not exist.");
        }
    }
}
