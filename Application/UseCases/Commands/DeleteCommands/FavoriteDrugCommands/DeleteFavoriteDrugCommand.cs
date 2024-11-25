using MediatR;

namespace Application.UseCases.Commands.DeleteCommands.FavoriteDrugCommands;

/// <summary>
/// Команда для удаления избранного лекарства.
/// </summary>
public record DeleteFavoriteDrugCommand(Guid Id) : IRequest<bool>;