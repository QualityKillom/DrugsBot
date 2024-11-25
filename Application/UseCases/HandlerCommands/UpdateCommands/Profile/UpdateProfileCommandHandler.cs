using Application.Interfaces.Repositories.ReadRepository.IProfileRepositories;
using Application.Interfaces.Repositories.WriteRepository.IProfileRepositories;
using Application.UseCases.Commands.UpdateCommands.ProfileCommands;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.HandlerCommands.UpdateCommands.Profile;

/// <summary>
/// Хендлер для обновления профиля.
/// </summary>
public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, bool>
{
    private readonly IProfileReadRepository _profileReadRepository;
    private readonly IProfileWriteRepository _profileWriteRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="UpdateProfileCommandHandler"/>.
    /// </summary>
    /// <param name="profileWriteRepository"></param>
    /// <param name="profileReadRepository"></param>
    public UpdateProfileCommandHandler(
        IProfileWriteRepository profileWriteRepository,
        IProfileReadRepository profileReadRepository)
    {
        _profileWriteRepository = profileWriteRepository;
        _profileReadRepository = profileReadRepository;
    }

    /// <summary>
    /// Обрабатывает команду обновления данных профиля.
    /// </summary>
    /// <param name="request">Команда для обновления данных профиля.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновленная сущность <see cref="Profile"/>, либо null, если обновление невозможно.</returns>
    public async Task<bool> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await _profileReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (!string.IsNullOrEmpty(request.ExternalId))
        {
            profile = new Domain.Entities.Profile(request.ExternalId, request.Email);
        }

        await _profileWriteRepository.UpdateAsync(profile, cancellationToken);
        return true;
    }
}