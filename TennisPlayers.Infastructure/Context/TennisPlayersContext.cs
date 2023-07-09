using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TennisPlayers.Domain.Models;

namespace TennisPlayers.Infastructure.Context
{
    public class TennisPlayersContext : DbContext
    {
        public TennisPlayersContext(DbContextOptions<TennisPlayersContext> options) : base(options)
        {
        }

        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<AthleteTournament> AthleteTournaments { get; set; }
        public DbSet<AthleteSponsor> AthleteSponsors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AthleteTournament>()
                .HasKey(pc => new { pc.AthleteId, pc.TournamentId });
            modelBuilder.Entity<AthleteTournament>()
                .HasOne(a => a.Athlete)
                .WithMany(pc => pc.AthleteTournaments)
                .HasForeignKey(a => a.AthleteId);
            modelBuilder.Entity<AthleteTournament>()
                .HasOne(t => t.Tournament)
                .WithMany(pc => pc.AthleteTournaments)
                .HasForeignKey(t => t.TournamentId);


            modelBuilder.Entity<AthleteSponsor>()
                .HasKey(pc => new { pc.AthleteId, pc.SponsorId });
            modelBuilder.Entity<AthleteSponsor>()
                .HasOne(a => a.Athlete)
                .WithMany(pc => pc.AthleteSponsors)
                .HasForeignKey(a => a.AthleteId);
            modelBuilder.Entity<AthleteSponsor>()
                .HasOne(s => s.Sponsor)
                .WithMany(pc => pc.AthleteSponsors)
                .HasForeignKey(s => s.SponsorId);
        }
    }
}
