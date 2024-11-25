using Application.Interfaces.Repositories.ReadRepository.ICountryRepositories;
using Application.Interfaces.Repositories.WriteRepository.ICountryRepositories;
using Application.UseCases.Commands.UpdateCommands.CountryCommands;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.HandlerCommands.UpdateCommands.Country;

/// <summary>
/// Хендлер для обновления информации о стране.
/// </summary>
public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Domain.Entities.Country?>
{
    private readonly ICountryReadRepository _countryReadRepository;
    private readonly ICountryWriteRepository _countryWriteRepository;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="UpdateCountryCommandHandler"/>.
    /// </summary>
    /// <param name="countryWriteRepository"></param>
    /// <param name="countryReadRepository"></param>
    public UpdateCountryCommandHandler(ICountryWriteRepository countryWriteRepository,
        ICountryReadRepository countryReadRepository)
    {
        _countryWriteRepository = countryWriteRepository;
        _countryReadRepository = countryReadRepository;
    }

    /// <summary>
    /// Обработчик команды обновления страны.
    /// </summary>
    /// <param name="request">Данные для обновления страны.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленная сущность <see cref="Country"/>, либо null, если обновление невозможно.</returns>
    public async Task<Domain.Entities.Country?> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryReadRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (!string.IsNullOrEmpty(request.Name))
            country.UpdateName(request.Name);

        if (!string.IsNullOrEmpty(request.Code))
            country.UpdateCode(request.Code);

        await _countryWriteRepository.UpdateAsync(country, cancellationToken);

        return country;
    }
}