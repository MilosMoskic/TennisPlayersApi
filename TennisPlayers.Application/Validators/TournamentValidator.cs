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
                .WithMessage("Tournament should contain only letters.");
            RuleFor(c => c.SurfaceType)
                .NotNull()
                .WithMessage("Sourface type cannot be null.")
                .NotEmpty()
                .WithMessage("Sourface type cannot be empty.")
                .Must(c => surfaceType.Contains(c))
                .WithMessage("Please only use one of these: " + String.Join(",", surfaceType));
            RuleFor(c => c.StartDate)
                .NotNull()
                .WithMessage("Start date cannot be null.")
                .NotEmpty()
                .WithMessage("Start date cannot be empty.")
                .LessThan(c => c.EndDate)
                .WithMessage("Start date must be earlier than End Date.")
                .Matches(new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"))
                .WithMessage("Date is not valid.");
            RuleFor(c => c.EndDate)
                .NotNull()
                .WithMessage("End date cannot be null.")
                .NotEmpty()
                .WithMessage("End date cannot be empty.")
                .GreaterThan(c => c.StartDate)
                .WithMessage("End date must be later than Start Date.")
                .Matches(new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"))
                .WithMessage("Date is not valid.");
        }
    }
}
