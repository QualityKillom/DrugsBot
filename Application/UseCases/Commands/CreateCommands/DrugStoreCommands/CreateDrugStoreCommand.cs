﻿using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.CreateCommands.DrugStoreCommands;

/// <summary>
/// Команда для создания аптеки.
/// </summary>
public record CreateDrugStoreCommand(string DrugNetwork, int Number, Address Address) : IRequest<Guid>;