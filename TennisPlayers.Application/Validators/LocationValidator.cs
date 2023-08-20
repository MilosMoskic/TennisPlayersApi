using FluentValidation;
using System.Text.RegularExpressions;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Validators
{
    public class LocationValidator : AbstractValidator<LocationDto>
    {
        public LocationValidator()
        {
            RuleFor(c => c.CityName)
                .NotNull()
                .WithMessage("City Name Name cannot be null.")
                .NotEmpty()
                .WithMessage("CityName Name cannot be empty.")
                .Matches(new Regex(@"[A-Za-z]"))
                .WithMessage("City Name should contain only letters.");
        }
    }
}
