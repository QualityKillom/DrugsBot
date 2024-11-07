using System.Data;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class DrugStoreValidator : AbstractValidator<DrugStore>
{
    public DrugStoreValidator(DrugNetwork drugNetwork)
    {
        RuleFor(ds => ds.DrugNetwork)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLenght);
        RuleFor(ds => ds.Number)
            .GreaterThan(0).WithMessage(ValidationMessage.WrongPolarity);
            //не сильно понял чо надо :( 
        RuleFor(ds => ds.Address)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        RuleFor(ds => ds.Address.Street)
            .Length(3, 100).WithMessage(ValidationMessage.WrongLenght);
        RuleFor(ds => ds.Address.City)
            .Length(2, 50).WithMessage(ValidationMessage.WrongLenght);
        RuleFor(ds => ds.Address.PostalCode.ToString())
            .Matches(@"^[1-9][0-9]{4,5}$");
    }
}