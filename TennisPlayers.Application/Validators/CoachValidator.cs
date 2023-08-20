using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Domain.Validators
{
    public class CoachValidator : AbstractValidator<CoachDto>
    {
        public CoachValidator()
        { 

            RuleFor(c => c.FirstName)
                .NotNull()
                .WithMessage("First Name cannot be null.")
                .NotEmpty()
                .WithMessage("First Name cannot be empty.")
                .Matches(new Regex(@"[A-Za-z]"))
                .WithMessage("First Name should contain only letters.");
            RuleFor(c => c.LastName)
                .NotNull()
                .WithMessage("Last Name cannot be null.")
                .NotEmpty()
                .WithMessage("Last Name cannot be empty.")
                .Matches(new Regex(@"[A-Za-z]"))
                .WithMessage("Last Name should contain only letters.");
        }
    }
}
