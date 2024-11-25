using Bogus;
using Domain.Entities;

namespace UnitTest.GenerateTest.EntitiesGenerator;

public static class CountryGenerator
{
         /// <summary>
         /// Генератор сущности Country для тестов
         /// </summary>
        private static readonly Faker<Country> _fakerCountry = new Faker<Country>()
        .CustomInstantiator(c => new Country(
            c.Address.Country(),
            c.PickRandom(Country.CountryCodes.ToList())
        ));

    /// <summary>
    /// Генерация страны
    /// </summary>
    /// <returns></returns>
    public static Country Generator()
    {
        return _fakerCountry.Generate();
    }
}