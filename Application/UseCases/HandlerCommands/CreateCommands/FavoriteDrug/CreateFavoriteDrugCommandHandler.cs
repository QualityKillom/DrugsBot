using Application.Interfaces.Repositories.ReadRepository.IDrugRepositories;
using Application.Interfaces.Repositories.ReadRepository.IDrugStoreRepositories;
using Application.Interfaces.Repositories.ReadRepository.IProfileRepositories;
using Application.Interfaces.Repositories.WriteRepository.IFavoriteDrugRepositories;
using Application.UseCases.Commands.CreateCommands.FavoriteDrugCommands;
using MediatR;

namespace Application.UseCases.HandlerCommands.CreateCommands.FavoriteDrug;

/// <summary>
/// Хендлер для создания избранного лекарства.
/// </summary>
public class CreateFavoriteDrugCommandHandler : IRequestHandler<CreateFavoriteDrugCommand, Guid>
{
    private readonly IDrugReadRepository _drugReadRepository;
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;
    private readonly IFavoriteDrugWriteRepository _favoriteDrugWriteRepository;
    private readonly IProfileReadRepository _profileReadRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="CreateFavoriteDrugCommandHandler"/>.
    /// </summary>
    /// <param name="favoriteDrugWriteRepository">Репозиторий для записи избранного лекарства.</param>
    /// <param name="profileReadRepository">Репозиторий для чтения данных о профилях.</param>
    /// <param name="drugReadRepository">Репозиторий для чтения данных о лекарствах.</param>
    /// <param name="drugStoreReadRepository">Репозиторий для чтения данных об аптеках.</param>
    public CreateFavoriteDrugCommandHandler(
        IFavoriteDrugWriteRepository favoriteDrugWriteRepository,
        IProfileReadRepository profileReadRepository,
        IDrugReadRepository drugReadRepository,
        IDrugStoreReadRepository drugStoreReadRepository)
    {
        _favoriteDrugWriteRepository = favoriteDrugWriteRepository;
        _profileReadRepository = profileReadRepository;
        _drugReadRepository = drugReadRepository;
        _drugStoreReadRepository = drugStoreReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду для создания избранного лекарства.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Guid> Handle(CreateFavoriteDrugCommand request, CancellationToken cancellationToken)
    {
        var profile = await _profileReadRepository.GetByIdAsync(request.ProfileId, cancellationToken);

        var drug = await _drugReadRepository.GetByIdAsync(request.DrugId, cancellationToken);

        Domain.Entities.DrugStore? drugStore = null;
        if (request.DrugStoreId.HasValue)
        {
            drugStore = await _drugStoreReadRepository.GetByIdAsync(request.DrugStoreId.Value, cancellationToken);
        }

        var favoriteDrug = new Domain.Entities.FavoriteDrug(profile, request.ProfileId,  request.DrugId,drug, request.DrugStoreId,
            drugStore);

        await _favoriteDrugWriteRepository.AddAsync(favoriteDrug, cancellationToken);

        return favoriteDrug.Id;
    }
}