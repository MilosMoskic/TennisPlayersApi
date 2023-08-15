﻿using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Services;
using TennisPlayers.Domain.Models;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SponsorController : Controller
    {
        public readonly ISponsorService _sponsorService;
        public SponsorController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSponsors()
        {
            var result = await _sponsorService.GetAllSponsors();
            return Ok(result);
        }

        [HttpGet("[action]/{sponsorId}")]
        [ProducesResponseType(200, Type = typeof(Sponsor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSponsorById(int sponsorId)
        {
            if (!_sponsorService.SponsorExists(sponsorId))
                return NotFound("Sponsor does not exist");

            var sponsor = _sponsorService.GetSponsorById(sponsorId);
            return Ok(sponsor);
        }

        [HttpGet("[action]/{sponsorName}")]
        [ProducesResponseType(200, Type = typeof(Sponsor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSponsorByName(string sponsorName)
        {
            if (!_sponsorService.SponsorExists(sponsorName))
                return NotFound("Sponsor does not exist");

            var sponsor = _sponsorService.GetSponsorByName(sponsorName);
            return Ok(sponsor);
        }

        [HttpGet("[action]/{netWorth}")]
        [ProducesResponseType(200, Type = typeof(Sponsor))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSponsorByNW(decimal netWorth)
        {
            var sponsor = await _sponsorService.GetSponsorsByNW(netWorth);
            return Ok(sponsor);
        }
    }
}