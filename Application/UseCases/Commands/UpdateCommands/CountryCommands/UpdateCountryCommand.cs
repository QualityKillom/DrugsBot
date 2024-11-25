using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.UpdateCommands.CountryCommands;

/// <summary>
/// Команда для обновления информации о стране.
/// </summary>
public record UpdateCountryCommand(Guid Id, string Name, string Code) : IRequest<Country?>;