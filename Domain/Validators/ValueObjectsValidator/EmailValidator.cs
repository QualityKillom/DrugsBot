
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validators;

public sealed class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(e => e.Value)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 255).WithMessage(ValidationMessage.WrongLenght)
            .Matches(@"^[a-zA-Z0-9._%+@-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage("Значение {PropertyName} не является электронной почтой.");
    }
}