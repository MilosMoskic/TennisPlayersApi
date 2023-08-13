﻿using Microsoft.AspNetCore.Mvc;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Services;

namespace iTennisPlayersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoachController : Controller
    {
        private readonly ICoachService _coachService;

        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoaches()
        {
            var result = await _coachService.GetAllCoaches();
            return Ok(result);
        }

        [HttpGet("{coachId:int}")]
        public async Task<IActionResult> GetCoachById(int coachId)
        {
            if (!_coachService.CoachExists(coachId))
                return NotFound("Coach does not exist");

            var coach = _coachService.GetCoachById(coachId);
            return Ok(coach);
        }

        [HttpGet("{lastName}")]
        public async Task<IActionResult> GetCoachByLastName(string lastName)
        {
            if (!_coachService.CoachExists(lastName))
                return NotFound("Coach does not exist");

            var coach = await _coachService.GetCoachesByLastName(lastName);
            return Ok(coach);
        }
    }
}
