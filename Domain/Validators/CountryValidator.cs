using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;


public class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidationMessage.WrongLenght)
            .Matches(@"^[a-zA-Zа-яА-Я\-\s]+$").WithMessage(ValidationMessage.WrongText);
        RuleFor(c => c.Code)
            .Length(2).WithMessage(ValidationMessage.WrongLenght)
            .Matches(@"^[A-Z]{2}").WithMessage(ValidationMessage.WrongText)
            .Must(BeAValidCountryCode).WithMessage(ValidationMessage.CountryCodeInvalid);
    }
    private bool BeAValidCountryCode(string countryCodeId)
    {
        return Country.CountryCodes.Contains(countryCodeId);
    }
   
}