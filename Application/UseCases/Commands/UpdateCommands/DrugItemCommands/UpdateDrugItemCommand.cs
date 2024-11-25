using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.UpdateCommands.DrugItemCommands;

/// <summary>
/// Команда для обновления связи препарата и аптеки.
/// </summary>
public record UpdateDrugItemCommand(Guid Id, decimal? Cost, int? Count) : IRequest<DrugItem?>;