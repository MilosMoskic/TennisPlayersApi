using FluentValidation;
using System.Text.RegularExpressions;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Domain.Validators
{
    public class CoachValidator : AbstractValidator<CoachDto>
    {
        private readonly char[] specialCharacters = { '+', '&', '|', '!', '(', ')', '{', '}', '[', ']', '^', '~', '*', '?', ':', '/' };
        public CoachValidator()
        { 

            RuleFor(c => c.FirstName)
                .NotNull()
                .WithMessage("First Name cannot be null.")
                .NotEmpty()
                .WithMessage("First Name cannot be empty.")
                .Must(ContainNoNumbers)
                .WithMessage("The input cannot contain numbers.")
                .Must(ContainNoSpecialCharacters)
                .WithMessage("The input cannot contain special characters.");
            RuleFor(c => c.LastName)
                .NotNull()
                .WithMessage("Last Name cannot be null.")
                .NotEmpty()
                .WithMessage("Last Name cannot be empty.")
                .Must(ContainNoNumbers)
                .WithMessage("The input cannot contain numbers.")
                .Must(ContainNoSpecialCharacters)
                .WithMessage("The input cannot contain special characters.");
        }
        private bool ContainNoNumbers(string input)
        {
            return !input.Any(char.IsDigit);
        }

        private bool ContainNoSpecialCharacters(string input)
        {
            return !input.Any(s => specialCharacters.Contains(s));
        }
    }
}
