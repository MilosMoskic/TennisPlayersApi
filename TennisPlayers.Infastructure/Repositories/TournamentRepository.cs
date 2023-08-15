﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Models;
using TennisPlayers.Infastructure.Context;

namespace TennisPlayers.Infastructure.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly TennisPlayersContext _context;

        public TournamentRepository(TennisPlayersContext context)
        {
            _context = context;
        }

        public Tournament GetTournament(int id)
        {
            return _context.Tournaments.Where(t => t.Id == id).FirstOrDefault();
        }

        public Tournament GetTournament(string name)
        {
            return _context.Tournaments.Where(t => t.Name == name).FirstOrDefault();
        }

        public Task<List<Tournament>> GetTournaments()
        {
            return _context.Tournaments.ToListAsync();
        }

        public bool TournamentExists(int id)
        {
            return _context.Tournaments.Any(t => t.Id == id);
        }

        public bool TournamentExists(string name)
        {
            return _context.Tournaments.Any(t => t.Name == name);
        }
    }
}