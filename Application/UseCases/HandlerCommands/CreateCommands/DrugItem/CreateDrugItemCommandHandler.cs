using Application.Interfaces.Repositories.ReadRepository.IDrugRepositories;
using Application.Interfaces.Repositories.ReadRepository.IDrugStoreRepositories;
using Application.Interfaces.Repositories.WriteRepository.IDrugItemRepositories;
using Application.UseCases.Commands.CreateCommands.DrugItemCommands;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.HandlerCommands.CreateCommands.DrugItem;

/// <summary>
/// Хендлер для создания связи препарата и аптеки.
/// </summary>
public class CreateDrugItemCommandHandler : IRequestHandler<CreateDrugItemCommand, Domain.Entities.DrugItem?>
{
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;
    private readonly IDrugReadRepository _drugReadRepository;
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;

    /// <summary>
    /// Конструктор хендлера для создания связи препарата и аптеки.
    /// </summary>
    /// <param name="drugItemWriteRepository">Репозиторий для записи связей препарата и аптеки.</param>
    /// <param name="drugReadRepository">Репозиторий для чтения данных о препаратах.</param>
    /// <param name="drugStoreReadRepository">Репозиторий для чтения данных об аптеках.</param>
    public CreateDrugItemCommandHandler(
        IDrugItemWriteRepository drugItemWriteRepository,
        IDrugReadRepository drugReadRepository,
        IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
        _drugReadRepository = drugReadRepository;
        _drugStoreReadRepository = drugStoreReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду создания связи между препаратом и аптекой.
    /// </summary>
    /// <param name="request">Команда с данными для создания связи.</param>
    /// <param name="cancellationToken">Токен отмены для управления задачей.</param>
    /// <returns>Созданная сущность <see cref="DrugItem"/>, либо null в случае ошибки.</returns>
    public async Task<Domain.Entities.DrugItem?> Handle(CreateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drug = await _drugReadRepository.GetByIdAsync(request.DrugId, cancellationToken);
        

        var drugStore = await _drugStoreReadRepository.GetByIdAsync(request.DrugStoreId, cancellationToken);
       

        var drugItem = new Domain.Entities.DrugItem(
            request.DrugId,
            request.DrugStoreId,
            request.Cost,
            request.Count,
            drug,
            drugStore
        );

        await _drugItemWriteRepository.AddAsync(drugItem, cancellationToken);

        return drugItem;
    }
}