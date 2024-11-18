using Domain.DomainEvents;
using FluentValidation;

namespace Domain.Validators.EventsValidator;

public class DrugItemUpdatedEventValidator : AbstractValidator<DrugItemUpdatedEvent>
{
    public DrugItemUpdatedEventValidator()
    {
        RuleFor(d => d.NewAmount)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessage.WrongPolarity)
            .LessThanOrEqualTo(10000).WithMessage(ValidationMessage.WrongNumber);
    }
}