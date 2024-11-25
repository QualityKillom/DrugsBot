using Application.Interfaces.Repositories.ReadRepository.IDrugRepositories;
using Application.Interfaces.Repositories.WriteRepository.IDrugRepositories;
using Application.UseCases.Commands.CreateCommands.DrugCommands;
using MediatR;

namespace Application.UseCases.HandlerCommands.CreateCommands.Drug;

/// <summary>
/// Обработчик команды для создания нового лекарства.
/// </summary>
public class CreateDrugCommandHandler : IRequestHandler<CreateDrugCommand, Domain.Entities.Drug?>
{
    private readonly IDrugReadRepository _drugReadRepository;
    private readonly IDrugWriteRepository _drugWriteRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="CreateDrugCommandHandler"/>.
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий для записи данных о лекарствах.</param>
    /// <param name="drugReadRepository">Репозиторий для чтения данных о лекарствах.</param>
    public CreateDrugCommandHandler(IDrugWriteRepository drugWriteRepository,
        IDrugReadRepository drugReadRepository)
    {
        _drugWriteRepository = drugWriteRepository;
        _drugReadRepository = drugReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду создания нового лекарства.
    /// </summary>
    /// <param name="request">Данные для создания лекарства.</param>
    /// <param name="cancellationToken">Токен для отмены операции.</param>
    /// <returns>Созданное лекарство или <c>null</c>, если операция не выполнена.</returns>
    public async Task<Domain.Entities.Drug?> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = new Domain.Entities.Drug(
            request.Name,
            request.Manufacturer,
            request.CountryCodeId,
            request.Country,
            new List<Domain.Entities.DrugItem>()
        );

        await _drugWriteRepository.AddAsync(drug, cancellationToken);

        return drug;
    }
}