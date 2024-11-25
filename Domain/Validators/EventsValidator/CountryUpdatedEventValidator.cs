using Domain.DomainEvents;
using Domain.Entities;
using FluentValidation;

namespace Domain.Validators.EventsValidator;

public class CountryUpdatedEventValidator : AbstractValidator<CountryUpdateEvent>
{
    public CountryUpdatedEventValidator()
    {
        RuleFor(x => x.PreviousValue)
            .NotEmpty().WithMessage("Предыдущее значение не может быть пустым.");
        RuleFor(x => x.UpdatedValue)
            .NotEmpty().WithMessage("Новое значение не может быть пустым.");

        RuleFor(x => x.UpdatedValue)
            .Must(BeAValidCountryCode)
            .WithMessage("Неверный код страны.");
    }

    private bool BeAValidCountryCode(string code)
    {
        return Country.CountryCodes.Contains(code);
    }
}