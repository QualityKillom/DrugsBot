using Application.Interfaces.Repositories.ReadRepository.ICountryRepositories;
using Application.Interfaces.Repositories.WriteRepository.ICountryRepositories;
using Application.UseCases.Commands.CreateCommands.CountryCommands;
using MediatR;

namespace Application.UseCases.HandlerCommands.CreateCommands.Country;

/// <summary>
/// Хендлер для создания новой страны.
/// </summary>
public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Domain.Entities.Country?>
{
    private readonly ICountryReadRepository _countryReadRepository;
    private readonly ICountryWriteRepository _countryWriteRepository;

    /// <summary>
    /// Конструктор хендлера.
    /// </summary>
    /// <param name="countryWriteRepository"></param>
    /// <param name="countryReadRepository"></param>
    public CreateCountryCommandHandler(ICountryWriteRepository countryWriteRepository,
        ICountryReadRepository countryReadRepository)
    {
        _countryWriteRepository = countryWriteRepository;
        _countryReadRepository = countryReadRepository;
    }

    /// <summary>
    /// Обработчик команды создания новой страны.
    /// </summary>
    /// <param name="request">Данные для создания страны.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданная страна.</returns>
    public async Task<Domain.Entities.Country?> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var existingCountry = await _countryReadRepository.GetByIdAsync(request.Id, cancellationToken);
        
        var country = new Domain.Entities.Country(
            request.Name,
            request.Code
        );

        await _countryWriteRepository.AddAsync(country, cancellationToken);

        return country;
    }
}