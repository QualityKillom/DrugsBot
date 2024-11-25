using MediatR;

namespace Application.UseCases.Commands.DeleteCommands.ProfileCommands;

/// <summary>
/// Команда для удаления профиля.
/// </summary>
public record DeleteProfileCommand(Guid Id) : IRequest<bool>;