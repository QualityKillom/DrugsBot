using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CreateCommands.DrugItemCommands;

/// <summary>
/// Команда для создания связи препарата и аптеки.
/// </summary>
public record CreateDrugItemCommand(Guid DrugId, Guid DrugStoreId, decimal Cost, int Count) : IRequest<DrugItem?>;