using Application.Interfaces.Repositories.ReadRepository.IDrugItemRepositories;
using Application.Interfaces.Repositories.WriteRepository.IDrugItemRepositories;
using Application.UseCases.Commands.UpdateCommands.DrugItemCommands;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.HandlerCommands.UpdateCommands.DrugItem;

/// <summary>
/// Хендлер для обновления связи препарата и аптеки.
/// </summary>
public class UpdateDrugItemCommandHandler : IRequestHandler<UpdateDrugItemCommand, Domain.Entities.DrugItem?>
{
    private readonly IDrugItemReadRepository _drugItemReadRepository;
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="UpdateDrugItemCommandHandler"/>.
    /// </summary>
    /// <param name="drugItemWriteRepository">Репозиторий для записи данных о связях препаратов и аптек.</param>
    /// <param name="drugItemReadRepository">Репозиторий для чтения данных о связях препаратов и аптек.</param>
    public UpdateDrugItemCommandHandler(
        IDrugItemWriteRepository drugItemWriteRepository,
        IDrugItemReadRepository drugItemReadRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
        _drugItemReadRepository = drugItemReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду обновления связи препарата и аптеки.
    /// </summary>
    /// <param name="request">Данные для обновления данных товара.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Обновленная сущность <see cref="DrugItem"/>, либо null, если обновление невозможно.</returns>
    public async Task<Domain.Entities.DrugItem?> Handle(UpdateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drugItem = await _drugItemReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (request.Cost.HasValue)
            drugItem.UpdateCost(request.Cost.Value);

        if (request.Count.HasValue)
            drugItem.UpdateCount(request.Count.Value);

        await _drugItemWriteRepository.UpdateAsync(drugItem, cancellationToken);

        return drugItem;
    }
}