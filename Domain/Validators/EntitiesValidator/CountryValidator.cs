using Domain.Entities;
using FluentValidation;

namespace Domain.Validators.EntitiesValidator;


public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(c => c.Name)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLenght)
            .Matches(@"^[a-zA-Zа-яА-Я\-\s]+$").WithMessage(ValidationMessage.WrongText);
        RuleFor(c => c.Code)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2).WithMessage(ValidationMessage.WrongLenght)
            .Matches(@"^[A-Z]{2}").WithMessage(ValidationMessage.WrongText)
            .Must(BeAValidCountryCode).WithMessage(ValidationMessage.CountryCodeInvalid);
    }
    private bool BeAValidCountryCode(string countryCodeId)
    {
        return Country.CountryCodes.Contains(countryCodeId);
    }
   
}