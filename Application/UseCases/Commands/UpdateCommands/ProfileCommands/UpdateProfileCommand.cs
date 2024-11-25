using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.UpdateCommands.ProfileCommands;

/// <summary>
/// Команда для обновления профиля.
/// </summary>
public record UpdateProfileCommand(Guid Id, string? ExternalId, Email? Email) : IRequest<bool>;