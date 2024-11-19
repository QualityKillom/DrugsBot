using Domain.Entities;
using Domain.Validators;
using Domain.Validators.EntitiesValidator;
using FluentValidation;

namespace Domain.Entities;

/// <summary>
/// Лекарство
/// </summary>
public class Drug : BaseEntity<Drug>
{
    public Drug(string name, string manufacturer,string countryCodeId, Country country)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countryCodeId;
        Country = country;
        
        Validate();
    }

    public void Validate()
    {
        var validator = new DrugsValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(' ', result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Производитель
    /// </summary>
    public string Manufacturer { get; private set; }
    /// <summary>
    /// Код страны
    /// </summary>
    public string CountryCodeId { get; private set; }
    /// <summary>
    /// Страна
    /// </summary>
    public Country Country { get; private set; }
    public ICollection<DrugItem> DrugItems { get; private set; }
}