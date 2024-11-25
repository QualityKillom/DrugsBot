using Domain.Entities;

namespace Application.Interfaces.Repositories.WriteRepository.IDrugRepositories;

/// <summary>
/// Репозиторий записи для сущности Drug
/// </summary>
public interface IDrugWriteRepository : IWriteRepository<Drug>
{
    new IReadOnlyList<Drug> ReadRepository { get; }
}