using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class DrugsValidator : AbstractValidator<Drug>
{
    public DrugsValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 150).WithMessage(ValidationMessage.WrongLenght)
            .Matches(@"^[a-zA-Zа-яА-ЯёЁ0-9\s\-\.,\\:;'@]+$").WithMessage(ValidationMessage.WrongCharacters);
        
        RuleFor(d =>d.Manufacturer)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLenght)
            .Matches(@"^[a-zA-Zа-яА-ЯёЁ\s]+$").WithMessage(ValidationMessage.WrongCharacters);

        RuleFor(d => d.CountryCodeId)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Matches("^[A-Z]+$").WithMessage(ValidationMessage.WrongCharacters)
            .Must(BeAValidCountryCode).WithMessage(ValidationMessage.CountryCodeInvalid);
        
        RuleFor(d => d.Country)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
    }
    private bool BeAValidCountryCode(string countryCodeId)
    {
        return Country.CountryCodes.Contains(countryCodeId);
    }
}