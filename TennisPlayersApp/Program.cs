using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TennisPlayers.Application.Dto;
using TennisPlayers.Application.Interfaces;
using TennisPlayers.Application.Mediator.Handlers.CoachHandlers;
using TennisPlayers.Application.Services;
using TennisPlayers.Application.Validators;
using TennisPlayers.Domain.Interfaces;
using TennisPlayers.Domain.Validators;
using TennisPlayers.Infastructure.Context;
using TennisPlayers.Infastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddFluentValidation(options =>
    {
        // Validate child properties and root collection elements
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;

        // Automatic registration of validators in assembly
        options.RegisterValidatorsFromAssemblyContaining<AthleteValidator>();
    });

builder.Services.AddScoped<IAthleteRepository, AthleteRepository>();
builder.Services.AddScoped<IAthleteService, AthleteService>();
builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<ICoachService, CoachService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ISponsorService, SponsorService>();
builder.Services.AddScoped<ISponsorRepository, SponsorRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IAthleteTournamentRepository, AthleteTournamentRepository>();
builder.Services.AddScoped<IAthleteTournamentService, AthleteTournamentService>();
builder.Services.AddScoped<IAthleteSponsorRepository, AthleteSponsorRepository>();
builder.Services.AddScoped<IAthleteSponsorService, AthleteSponsorService>();

builder.Services.AddScoped<IValidator<CoachDto>, CoachValidator>();
builder.Services.AddScoped<IValidator<CountryDto>, CountryValidator>();
builder.Services.AddScoped<IValidator<LocationDto>, LocationValidator>();
builder.Services.AddScoped<IValidator<SponsorDto>, SponsorValidator>();
builder.Services.AddScoped<IValidator<TournamentDto>, TournamentValidator>();
builder.Services.AddScoped<IValidator<AthleteDto>, AthleteValidator>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetAllCoachesHandler)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TennisPlayersContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
