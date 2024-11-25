using MediatR;

namespace Application.UseCases.Commands.DeleteCommands.DrugItemCommands;

/// <summary>
/// Команда для удаления связи препарата и аптеки.
/// </summary>
public record DeleteDrugItemCommand(Guid Id) : IRequest<bool>;