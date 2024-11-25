using Domain.Interface;

namespace Domain.Events;

/// <summary>
/// Доменное событие обновления единицы лекарства.
/// </summary>
public sealed class DrugItemUpdateEvent : IDomainEvent
{
    internal DrugItemUpdateEvent(){}
}