using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class DrugStoreValidator : AbstractValidator<DrugStore>
    {
        public DrugStoreValidator()
        {
            RuleFor(ds => ds.DrugNetwork)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
                .Length(2,100).WithMessage(ValidationMessage.WrongLenght);
            RuleFor(ds => ds.Number)
                .GreaterThan(0).WithMessage(ValidationMessage.WrongPolarity);
            //не сильно понял чо надо :( 
            RuleFor(ds => ds.Address)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
        
        }
    
    }
}