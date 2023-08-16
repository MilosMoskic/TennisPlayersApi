﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TennisPlayers.Infastructure.Context;

#nullable disable

namespace TennisPlayers.Infastructure.Migrations
{
    [DbContext(typeof(TennisPlayersContext))]
    partial class TennisPlayersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TennisPlayers.Domain.Models.Athlete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Ranking")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalLoses")
                        .HasColumnType("int");

                    b.Property<int>("TotalWins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("CountryId");

                    b.ToTable("Athletes");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.AthleteSponsor", b =>
                {
                    b.Property<int>("AthleteId")
                        .HasColumnType("int");

                    b.Property<int>("SponsorId")
                        .HasColumnType("int");

                    b.HasKey("AthleteId", "SponsorId");

                    b.HasIndex("SponsorId");

                    b.ToTable("AthleteSponsors");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.AthleteTournament", b =>
                {
                    b.Property<int>("AthleteId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("AthleteId", "TournamentId");

                    b.HasIndex("TournamentId");

                    b.ToTable("AthleteTournaments");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NetWorth")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SurfaceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Athlete", b =>
                {
                    b.HasOne("TennisPlayers.Domain.Models.Coach", "Coach")
                        .WithMany("Athletes")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TennisPlayers.Domain.Models.Country", "Country")
                        .WithMany("Athletes")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.AthleteSponsor", b =>
                {
                    b.HasOne("TennisPlayers.Domain.Models.Athlete", "Athlete")
                        .WithMany("AthleteSponsors")
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TennisPlayers.Domain.Models.Sponsor", "Sponsor")
                        .WithMany("AthleteSponsors")
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Athlete");

                    b.Navigation("Sponsor");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.AthleteTournament", b =>
                {
                    b.HasOne("TennisPlayers.Domain.Models.Athlete", "Athlete")
                        .WithMany("AthleteTournaments")
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TennisPlayers.Domain.Models.Tournament", "Tournament")
                        .WithMany("AthleteTournaments")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Athlete");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Tournament", b =>
                {
                    b.HasOne("TennisPlayers.Domain.Models.Location", "Location")
                        .WithMany("Tournaments")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Athlete", b =>
                {
                    b.Navigation("AthleteSponsors");

                    b.Navigation("AthleteTournaments");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Coach", b =>
                {
                    b.Navigation("Athletes");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Country", b =>
                {
                    b.Navigation("Athletes");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Location", b =>
                {
                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Sponsor", b =>
                {
                    b.Navigation("AthleteSponsors");
                });

            modelBuilder.Entity("TennisPlayers.Domain.Models.Tournament", b =>
                {
                    b.Navigation("AthleteTournaments");
                });
#pragma warning restore 612, 618
        }
    }
}
