using MediatR;

namespace Application.UseCases.Commands.CreateCommands.FavoriteDrugCommands;

/// <summary>
/// Команда для создания избранного лекарства.
/// </summary>
public record CreateFavoriteDrugCommand(Guid ProfileId, Guid DrugId, Guid? DrugStoreId = null) : IRequest<Guid>;