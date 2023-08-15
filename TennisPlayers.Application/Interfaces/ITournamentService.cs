﻿using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Interfaces
{
    public interface ITournamentService
    {
        public Task<List<TournamentDto>> GetAllTournaments();
        public TournamentDto GetTournamentById(int id);
        public TournamentDto GetTournamentByName(string name);
        public bool TournamentExists(int id);
        public bool TournamentExists(string name);
    }
}