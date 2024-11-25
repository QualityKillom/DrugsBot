using MediatR;

namespace Application.UseCases.Commands.DeleteCommands.CountryCommands;

/// <summary>
/// Команда для удаления страны по её идентификатору.
/// </summary>
public record DeleteCountryCommand(Guid Id) : IRequest<bool>;