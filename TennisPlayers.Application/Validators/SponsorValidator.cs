using FluentValidation;
using System.Text.RegularExpressions;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Validators
{
    public class SponsorValidator : AbstractValidator<SponsorDto>
    {
        public SponsorValidator()
        {
            RuleFor(s => s.Name)
                .NotNull()
                .WithMessage("Name cannot be null.")
                .NotEmpty()
                .WithMessage("Name cannot be empty.")
                .Matches(new Regex(@"[A-Za-z]"))
                .WithMessage("Name should contain only letters.");
            RuleFor(s => s.NetWorth)
                .NotNull()
                .WithMessage("NetWorth cannot be null")
                .GreaterThanOrEqualTo(0)
                .WithMessage("NetWorth cannot be negative number.");
        }
    }
}
