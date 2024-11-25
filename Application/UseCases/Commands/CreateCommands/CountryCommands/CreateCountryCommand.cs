using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CreateCommands.CountryCommands;

/// <summary>
/// Команда для создания новой страны.
/// </summary>
public record CreateCountryCommand(Guid Id, string Name, string Code) : IRequest<Country?>;