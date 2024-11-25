using Application.Interfaces.Repositories.WriteRepository.IProfileRepositories;
using Application.UseCases.Commands.CreateCommands.ProfileCommands;
using MediatR;

namespace Application.UseCases.HandlerCommands.CreateCommands.Profile;

/// <summary>
/// Хендлер для создания профиля.
/// </summary>
public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, Guid>
{
    private readonly IProfileWriteRepository _profileWriteRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="CreateProfileCommandHandler"/>.
    /// </summary>
    /// <param name="profileWriteRepository"></param>
    public CreateProfileCommandHandler(IProfileWriteRepository profileWriteRepository)
    {
        _profileWriteRepository = profileWriteRepository;
    }

    /// <summary>
    /// Обработка команды для создания профиля.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Guid> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = new Domain.Entities.Profile(request.ExternalId, request.Email);
        await _profileWriteRepository.AddAsync(profile, cancellationToken);
        return profile.Id;
    }
}