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
        
        ValidateEntity(new DrugsValidator());
    }
    public Drug(string name, string manufacturer, string countryCodeId, Country country, List<DrugItem> drugItems)
    {
        DrugItems = drugItems;
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countryCodeId;
        Country = country;
        
        ValidateEntity(new DrugsValidator());
    }
    /// <summary>
    /// Метод для обновления названия
    /// </summary>
    /// <param name="name"></param>
    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
        }

        Name = name;
    }

    /// <summary>
    /// Метод для обновления производителя
    /// </summary>
    /// <param name="manufacturer"></param>
    public void UpdateManufacturer(string manufacturer)
    {
        if (string.IsNullOrWhiteSpace(manufacturer))
        {
            throw new ArgumentException("Manufacturer cannot be null or whitespace.", nameof(manufacturer));
        }

        Manufacturer = manufacturer;
    }

    /// <summary>
    /// Метод для обновления кода страны
    /// </summary>
    /// <param name="countryCodeId"></param>
    public void UpdateCountryCode(string countryCodeId)
    {
        if (string.IsNullOrWhiteSpace(countryCodeId))
        {
            throw new ArgumentException("CountryCodeId cannot be null or whitespace.", nameof(countryCodeId));
        }

        CountryCodeId = countryCodeId;
    }

    /// <summary>
    /// Метод для обновления страны
    /// </summary>
    /// <param name="country"></param>
    public void UpdateCountry(Country country)
    {
        if (country == null)
        {
            throw new ArgumentNullException(nameof(country), "Country cannot be null.");
        }

        Country = country;
    }

    /// <summary>
    /// Метод для обновления коллекции DrugItems
    /// </summary>
    /// <param name="drugItems"></param>
    public void UpdateDrugItems(ICollection<DrugItem> drugItems)
    {
        if (drugItems == null || !drugItems.Any())
        {
            throw new ArgumentException("DrugItems cannot be null or empty.", nameof(drugItems));
        }

        DrugItems = drugItems.ToList();
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
    /// <summary>
    /// Навигационное свойство для связи с DrugItem.
    /// </summary>
    public ICollection<DrugItem> DrugItems { get; private set; }
}