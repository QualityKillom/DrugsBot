using Bogus;
using Domain.Entities;

namespace UnitTest.GenerateTest;

public static class CountryGenerator
{
    private static readonly Faker<Country> _fakerCountry = new Faker<Domain.Entities.Country>()
        .CustomInstantiator(c => new Domain.Entities.Country(
            c.Address.Country(),
            c.PickRandom(Country.CountryCodes.ToList())
        ));

    public static Domain.Entities.Country Generator()
    {
        return _fakerCountry.Generate();
    }
}