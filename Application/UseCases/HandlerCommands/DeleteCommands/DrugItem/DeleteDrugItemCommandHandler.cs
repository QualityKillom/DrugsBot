using Application.Interfaces.Repositories.ReadRepository.IDrugItemRepositories;
using Application.Interfaces.Repositories.WriteRepository.IDrugItemRepositories;
using Application.UseCases.Commands.DeleteCommands.DrugItemCommands;
using MediatR;

namespace Application.UseCases.HandlerCommands.DeleteCommands.DrugItem;

/// <summary>
/// Хендлер для удаления связи препарата и аптеки.
/// </summary>
public class DeleteDrugItemCommandHandler : IRequestHandler<DeleteDrugItemCommand, bool>
{
    private readonly IDrugItemReadRepository _drugItemReadRepository;
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DeleteDrugItemCommandHandler"/>.
    /// </summary>
    /// <param name="drugItemWriteRepository">Репозиторий для записи и удаления данных о связях препаратов и аптек.</param>
    /// <param name="drugIteReadRepository">Репозиторий для чтения данных о связях препаратов и аптек.</param>
    public DeleteDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository,
        IDrugItemReadRepository drugIteReadRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
        _drugItemReadRepository = drugIteReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду удаления связи между препаратом и аптекой.
    /// </summary>
    /// <param name="request">Команда для удаления DrugItem.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Возвращает true, если удаление прошло успешно.</returns>
    public async Task<bool> Handle(DeleteDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drug = await _drugItemReadRepository.GetByIdAsync(request.Id, cancellationToken);

        await _drugItemWriteRepository.DeleteAsync(request.Id, cancellationToken);

        return true;
    }
}