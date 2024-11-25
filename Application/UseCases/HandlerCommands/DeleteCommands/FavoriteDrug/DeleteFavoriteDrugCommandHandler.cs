﻿using Application.Interfaces.Repositories.ReadRepository.IFavoriteDrugRepositories;
using Application.Interfaces.Repositories.WriteRepository.IFavoriteDrugRepositories;
using Application.UseCases.Commands.DeleteCommands.FavoriteDrugCommands;
using MediatR;

namespace Application.UseCases.HandlerCommands.DeleteCommands.FavoriteDrug;

/// <summary>
/// Хендлер для удаления избранного лекарства.
/// </summary>
public class DeleteFavoriteDrugCommandHandler : IRequestHandler<DeleteFavoriteDrugCommand, bool>
{
    private readonly IFavoriteDrugReadRepository _favoriteDrugReadRepository;
    private readonly IFavoriteDrugWriteRepository _favoriteDrugWriteRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="DeleteFavoriteDrugCommandHandler"/>.
    /// </summary>
    /// <param name="favoriteDrugWriteRepository"></param>
    /// <param name="favoriteDrugReadRepository"></param>
    public DeleteFavoriteDrugCommandHandler(IFavoriteDrugWriteRepository favoriteDrugWriteRepository,
        IFavoriteDrugReadRepository favoriteDrugReadRepository)
    {
        _favoriteDrugWriteRepository = favoriteDrugWriteRepository;
        _favoriteDrugReadRepository = favoriteDrugReadRepository;
    }

    /// <summary>
    /// Обработка команды удаления избранного лекарства.
    /// </summary>
    /// <param name="request">Команда для удаления FavoriteDrug.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Возвращает true, если удаление прошло успешно.</returns>
    /// <exception cref="EntityNotFoundException">Выбрасывается, если избранное лекарство с указанным идентификатором не найдено.</exception>
    public async Task<bool> Handle(DeleteFavoriteDrugCommand request, CancellationToken cancellationToken)
    {
        var favoriteDrug = await _favoriteDrugReadRepository.GetByIdAsync(request.Id, cancellationToken);

        await _favoriteDrugWriteRepository.DeleteAsync(request.Id, cancellationToken);
        return true;
    }
}