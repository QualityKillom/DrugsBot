using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validators.ValueObjectsValidator;

public class AddressValidator: AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(a => a.Street)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(3, 100).WithMessage(ValidationMessage.WrongLenght);
        
        RuleFor(a=>a.City)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(5, 50).WithMessage(ValidationMessage.WrongLenght);
        
        RuleFor(a=>a.House)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .GreaterThan(0).WithMessage(ValidationMessage.WrongPolarity);

        RuleFor(a => a.PostalCode)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .GreaterThanOrEqualTo(10000).WithMessage(ValidationMessage.WrongNumber)
            .LessThanOrEqualTo(999999).WithMessage(ValidationMessage.WrongNumber);
        
    }
}