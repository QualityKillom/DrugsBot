using Application.Interfaces.Repositories.ReadRepository.ICountryRepositories;
using Application.Interfaces.Repositories.WriteRepository.ICountryRepositories;
using Application.UseCases.Commands.DeleteCommands.CountryCommands;
using MediatR;

namespace Application.UseCases.HandlerCommands.DeleteCommands.Country;

/// <summary>
/// Хендлер для удаления страны.
/// </summary>
public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, bool>
{
    private readonly ICountryReadRepository _countryReadRepository;
    private readonly ICountryWriteRepository _countryWriteRepository;

    /// <summary>
    /// Инициализирует экземпляр класса <see cref="DeleteCountryCommandHandler"/>.
    /// </summary>
    /// <param name="countryWriteRepository"></param>
    /// <param name="countryReadRepository"></param>
    public DeleteCountryCommandHandler(ICountryWriteRepository countryWriteRepository,
        ICountryReadRepository countryReadRepository)
    {
        _countryWriteRepository = countryWriteRepository;
        _countryReadRepository = countryReadRepository;
    }

    /// <summary>
    /// Обработчик команды удаления страны.
    /// </summary>
    /// <param name="request">Данные для удаления страны.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает true, если удаление прошло успешно.</returns>
    public async Task<bool> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryReadRepository.GetByIdAsync(request.Id, cancellationToken);
        
        await _countryWriteRepository.DeleteAsync(request.Id, cancellationToken);
        return true;
    }
}