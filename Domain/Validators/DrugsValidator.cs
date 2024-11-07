using static Domain.Entities.Country;
using Domain.Entities;
using FluentValidation;
namespace Domain.Validators
{
    public class DrugsValidator : AbstractValidator<Drug>
    {
        public DrugsValidator()
        {
            
            RuleFor(d => d.Name)
                .NotNull().WithMessage(ValidationMessage.NotNull)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
                .Length(2, 150).WithMessage(ValidationMessage.WrongLenght)
                .Matches(@"^[a-zA-Zа-яА-Я\s]+$").WithMessage(ValidationMessage.WrongText);
            
            RuleFor(d => d.Manufacturer)
                .Matches(@"^[a-zA-Zа-яА-Я\s\-]+$").WithMessage(ValidationMessage.WrongText)
                .Length(2, 100).WithMessage(ValidationMessage.WrongLenght);

            RuleFor(d => d.CountryCodeId)
                .Length(2).WithMessage(ValidationMessage.WrongLenght)
                .Matches(@"^[A-Z]{2}").WithMessage(ValidationMessage.WrongText)
                .Must(BeAValidCountryCode).WithMessage(ValidationMessage.CountryCodeInvalid);
            
            bool BeAValidCountryCode(string countryCodeId)
            {
                return CountryCodes.ContainsKey(countryCodeId);
            }
        }
    }
}