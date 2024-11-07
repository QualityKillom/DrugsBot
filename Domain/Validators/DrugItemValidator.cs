using System.Text.RegularExpressions;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class DrugItemValidator : AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        RuleFor(di => di.Cost)
            .GreaterThan(0).WithMessage(ValidationMessage.WrongPolarity)
            .LessThanOrEqualTo(9999999.99m).WithMessage(ValidationMessage.WrongNumber)
            .Must(cost => Regex.IsMatch(cost.ToString("0.##"), @"^\d+(\.\d{1,2})?$"))
            .WithMessage(ValidationMessage.WrongCharacters);
        RuleFor(di => di.Count)
            .GreaterThan(0).WithMessage(ValidationMessage.WrongPolarity)
            .LessThanOrEqualTo(10000).WithMessage(ValidationMessage.WrongNumber);
    }
    
}