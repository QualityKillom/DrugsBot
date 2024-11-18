using Domain.Interface;
using Domain.Validators.EventsValidator;
using FluentValidation;

namespace Domain.DomainEvents;

public class DrugItemUpdatedEvent : IDomainEvent
{
    public Guid DrugItemId { get; }
    
    public double NewAmount { get; }
    
    public DrugItemUpdatedEvent(Guid drugItemId, double newAmount)
    {
        DrugItemId = drugItemId;
        NewAmount = newAmount;

        Validate();
    }
    
    private void Validate()
    {
        var validator = new DrugItemUpdatedEventValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}