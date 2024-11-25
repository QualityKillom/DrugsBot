using Application.Interfaces.Repositories.ReadRepository.IDrugStoreRepositories;
using Application.Interfaces.Repositories.WriteRepository.IDrugStoreRepositories;
using Application.UseCases.Commands.DeleteCommands.DrugStoreCommands;
using MediatR;

namespace Application.UseCases.HandlerCommands.DeleteCommands.DrugStore;

/// <summary>
/// Хендлер для удаления аптеки.
/// </summary>
public class DeleteDrugStoreCommandHandler : IRequestHandler<DeleteDrugStoreCommand, bool>
{
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DeleteDrugStoreCommandHandler"/>.
    /// </summary>
    /// <param name="drugStoreWriteRepository">Репозиторий для записи данных аптек.</param>
    /// <param name="drugStoreReadRepository">Репозиторий для чтения данных аптек.</param>
    public DeleteDrugStoreCommandHandler(
        IDrugStoreWriteRepository drugStoreWriteRepository,
        IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
        _drugStoreReadRepository = drugStoreReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду удаления аптеки.
    /// </summary>
    /// <param name="request">Команда для удаления DrugStore.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Возвращает true, если удаление прошло успешно.</returns>
    public async Task<bool> Handle(DeleteDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = await _drugStoreReadRepository.GetByIdAsync(request.Id, cancellationToken);

        await _drugStoreWriteRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}