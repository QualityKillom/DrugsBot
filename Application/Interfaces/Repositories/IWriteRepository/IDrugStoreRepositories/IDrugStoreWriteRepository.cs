using Domain.Entities;

namespace Application.Interfaces.Repositories.WriteRepository.IDrugStoreRepositories;

/// <summary>
/// Репозиторий записи для сущности DrugStore
/// </summary>
public interface IDrugStoreWriteRepository : IWriteRepository<DrugStore>
{
    IReadOnlyList<DrugStore> ReadRepository { get; }
}