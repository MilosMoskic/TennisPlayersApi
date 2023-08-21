using FluentValidation;
using System.Text.RegularExpressions;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Validators
{
    public class TournamentValidator : AbstractValidator<TournamentDto>
    {
        List<string> surfaceType = new List<string>() { "Clay", "Hard", "Grass" };
        public TournamentValidator()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .WithMessage("Tournament Name cannot be null.")
                .NotEmpty()
                .WithMessage("Tournament Name cannot be empty.")
                .Matches(new Regex(@"[A-Za-z]"))
                .WithMessage("Country should contain only letters.");
            RuleFor(c => c.SurfaceType)
                .NotNull()
                .WithMessage("Sourface type cannot be null.")
                .NotEmpty()
                .WithMessage("Sourface type cannot be empty.")
                .Must(c => surfaceType.Contains(c))
                .WithMessage("Please only use one of these: " + String.Join(",", surfaceType));
        }
    }
}
