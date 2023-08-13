using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Services;

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

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var result = await _countryService.GetAllCountries();
            return Ok(result);
        }

        [HttpGet("{countryId:int}")]
        public async Task<IActionResult> GetCountryById(int countryId)
        {
            if (!_countryService.CountryExists(countryId))
                return NotFound("Country does not exist");

            var coach = _countryService.GetCountryById(countryId);
            return Ok(coach);
        }

        [HttpGet("{countryName}")]
        public async Task<IActionResult> GetCountryByCountryName(string countryName)
        {
            if (!_countryService.CountryExists(countryName))
                return NotFound("Country does not exist");

            var coach = _countryService.GetCountryByName(countryName);
            return Ok(coach);
        }
    }
}
