using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class FavoriteDrugValidator : AbstractValidator<FavoriteDrug>
{
    public FavoriteDrugValidator()
    {
        RuleFor(fd => fd.Profile)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(fd => fd.ExternalUserId)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
            
        RuleFor(fd => fd.DrugId)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        
        RuleFor(fd => fd.Drug)
            .NotNull().WithMessage(ValidationMessage.NotNull)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        
    }
}
