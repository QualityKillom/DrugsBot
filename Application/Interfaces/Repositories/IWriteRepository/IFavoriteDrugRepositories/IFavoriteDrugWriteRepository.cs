﻿using Domain.Entities;

namespace Application.Interfaces.Repositories.WriteRepository.IFavoriteDrugRepositories;

/// <summary>
/// Репозиторий записи для сущности FavoriteDrug
/// </summary>
public interface IFavoriteDrugWriteRepository : IWriteRepository<FavoriteDrug>
{
    new IReadOnlyList<FavoriteDrug> ReadRepository { get; }
}