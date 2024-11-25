using Domain.Entities;

namespace Application.Interfaces.Repositories.WriteRepository.IDrugItemRepositories;

/// <summary>
/// Репозиторий записи для сущности DrugItem
/// </summary>
public interface IDrugItemWriteRepository : IWriteRepository<DrugItem>
{
    new IReadOnlyList<DrugItem> ReadRepository { get; }
}