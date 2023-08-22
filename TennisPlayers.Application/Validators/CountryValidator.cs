using FluentValidation;
using System.Text.RegularExpressions;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Validators
{
    public class CountryValidator : AbstractValidator<CountryDto>
    {
        public CountryValidator()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .WithMessage("Country Name cannot be null.")
                .NotEmpty()
                .WithMessage("Country Name cannot be empty.")
                .Matches(new Regex(@"[A-Za-z]"))
                .WithMessage("Country should contain only letters.");
            RuleFor(c => c.Abbreviation)
                .NotNull()
                .WithMessage("Abbreviation cannot be null.")
                .NotEmpty()
                .WithMessage("Abbreviation cannot be empty.")
                .MinimumLength(2).MaximumLength(3)
                .WithMessage("Abbreviation must be either 2 or 3 characters long.")
                .Matches(new Regex(@"^[A-Z]+$"))
                .WithMessage("Abbreviation should contain only uppercase letters.");
        }
    }
}
