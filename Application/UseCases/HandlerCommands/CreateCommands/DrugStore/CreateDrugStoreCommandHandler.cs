﻿using Application.Interfaces.Repositories.WriteRepository.IDrugStoreRepositories;
using Application.UseCases.Commands.CreateCommands.DrugStoreCommands;
using MediatR;

namespace Application.UseCases.HandlerCommands.CreateCommands.DrugStore;

/// <summary>
/// Хендлер для создания аптеки.
/// </summary>
public class CreateDrugStoreCommandHandler : IRequestHandler<CreateDrugStoreCommand, Guid>
{
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="CreateDrugStoreCommandHandler"/>.
    /// </summary>
    /// <param name="drugStoreWriteRepository">Репозиторий для записи данных аптек.</param>
    public CreateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
    }

    /// <summary>
    /// Обрабатывает команду создания новой аптеки.
    /// </summary>
    /// <param name="request">Команда с данными для создания аптеки.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Идентификатор созданной аптеки.</returns>
    public async Task<Guid> Handle(CreateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = new Domain.Entities.DrugStore(request.DrugNetwork, request.Number, request.Address);
        await _drugStoreWriteRepository.AddAsync(drugStore, cancellationToken);
        return drugStore.Id;
    }
}