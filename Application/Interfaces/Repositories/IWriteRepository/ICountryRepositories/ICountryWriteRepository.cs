using Domain.Entities;

namespace Application.Interfaces.Repositories.WriteRepository.ICountryRepositories;

/// <summary>
/// Репозиторий записи для сущности Country
/// </summary>
public interface ICountryWriteRepository : IWriteRepository<Country>
{
    new IReadOnlyList<Country> ReadRepository { get; }
}