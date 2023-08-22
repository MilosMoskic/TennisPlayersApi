using FluentValidation;
using System.Text.RegularExpressions;
using TennisPlayers.Application.Dto;

namespace TennisPlayers.Application.Validators
{
    public class AthleteValidator : AbstractValidator<AthleteDto>
    {
        List<string> status = new List<string>() { "Active", "Retired", "Injuired" };
        public AthleteValidator()
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
            RuleFor(c => c.Age)
                .NotNull()
                .WithMessage("Age cannot be null.")
                .GreaterThan(0)
                .WithMessage("Age must be grater than 0");
            RuleFor(c => c.TotalWins)
                .NotNull()
                .WithMessage("Total Wins cannot be null.")
                .Custom((x, context) =>
                {
                    if (x < 0)
                    {
                        context.AddFailure($"{x} is not a valid number or less than 0");
                    }
                });
            RuleFor(c => c.TotalLoses)
                .NotNull()
                .WithMessage("Total Loses cannot be null.")
                .Custom((x, context) =>
                {
                    if (x < 0)
                    {
                        context.AddFailure($"{x} is not a valid number or less than 0");
                    }
                });
            RuleFor(c => c.Ranking)
                .NotNull()
                .WithMessage("Ranking cannot be null.")
                .Custom((x, context) =>
                {
                    if (x < 0)
                    {
                        context.AddFailure($"{x} is not a valid number or less than 0");
                    }
                });
            RuleFor(c => c.Status)
                .NotNull()
                .WithMessage("Status cannot be null.")
                .NotEmpty()
                .WithMessage("Status cannot be empty.")
                .Must(c => status.Contains(c))
                .WithMessage("Please only use one of these: " + String.Join(",", status));

            //Validate ranking by status
            
            RuleFor(c => c).Custom((model, context) =>
            {
                if (model.Status == status[1])
                {
                    if (model.Ranking != 0)
                    {
                        context.AddFailure("Ranking must be 0 if athlete is retired.");
                    }
                }
                else if (model.Status == status[0] || model.Status == status[2])
                {
                    if (model.Ranking == 0)
                    {
                        context.AddFailure("Ranking cannot be 0 if athlete is active or injured.");
                    }
                }
            });
        }
    }
}
