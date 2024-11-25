using Application.Interfaces.Repositories.ReadRepository.IDrugRepositories;
using Application.Interfaces.Repositories.WriteRepository.IDrugRepositories;
using Application.UseCases.Commands.DeleteCommands.DrugCommands;
using MediatR;

namespace Application.UseCases.HandlerCommands.DeleteCommands.Drug;

/// <summary>
/// Хендлер для команды удаления лекарства.
/// </summary>
public class DeleteDrugCommandHandler : IRequestHandler<DeleteDrugCommand, bool>
{
    private readonly IDrugReadRepository _drugReadRepository;
    private readonly IDrugWriteRepository _drugWriteRepository;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DeleteDrugCommandHandler"/>.
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий записи.</param>
    /// <param name="drugReadRepository">Репозиторий чтения.</param>
    public DeleteDrugCommandHandler(IDrugWriteRepository drugWriteRepository, IDrugReadRepository drugReadRepository)
    {
        _drugWriteRepository = drugWriteRepository;
        _drugReadRepository = drugReadRepository;
    }

    /// <summary>
    /// Обработка команды удаления лекарства.
    /// </summary>
    /// <param name="request">Команда для удаления Drug.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Возвращает true, если удаление прошло успешно.</returns>
    public async Task<bool> Handle(DeleteDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = await _drugReadRepository.GetByIdAsync(request.Id, cancellationToken);

        await _drugWriteRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}