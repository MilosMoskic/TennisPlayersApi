﻿using Microsoft.EntityFrameworkCore;
using TennisPlayers.Application.Dto;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;
using TennisPlayers.Infastructure.Context;

namespace TennisPlayers.Infastructure.Repositories
{
    public class AthleteRepository : IAthleteRepository
    {
        private readonly TennisPlayersContext _context;

        public AthleteRepository(TennisPlayersContext context)
        {
            _context = context;
        }
        public Athlete GetAthlete(int id)
        {
            return _context.Athletes.Where(a => a.Id == id).FirstOrDefault();
        }

        public Athlete GetAthlete(string lastName)
        {
            return _context.Athletes.Where(a => a.LastName == lastName).FirstOrDefault();
        }

        public Athlete GetAthleteByRanking(int ranking)
        {
            return _context.Athletes.Where(a => a.Ranking == ranking).FirstOrDefault();
        }
        public ICollection<Athlete> GetAthletesByTournament(int tournamentId)
        {
            return _context.AthleteTournaments.Where(a => a.TournamentId == tournamentId).Select(a => a.Athlete).ToList();
        }

        public Task<List<Athlete>> GetAllAthletes()
        {
            return _context.Athletes.ToListAsync();
        }

        public decimal GetAthleteWinPercent(string name)
        {
            var athlete = _context.Athletes.Where(a => a.LastName == name).FirstOrDefault();

            return (athlete.TotalWins / (athlete.TotalWins + athlete.TotalLoses)) * 100;
        }

        public bool AthleteExists(int id)
        {
            return _context.Athletes.Any(a => a.Id == id);
        }

        public bool AthleteExists(string name)
        {
            return _context.Athletes.Any(a => a.LastName == name);
        }
    }
}
