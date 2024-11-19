using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public sealed class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        RuleFor(p => p.ExternalId)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .Length(2, 255).WithMessage(ValidationMessage.WrongLenght );
        RuleFor(p => p.Email)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

    }
}