using Domain.Entities;
using FluentAssertions;

namespace UnitTest.PositiveTest.CountryTest;

public class CountryPositiveTest
{
    private readonly Bogus.Faker _faker = new();

    [Fact]
    public void Add_Return_Country()
    {
        var name = _faker.Address.Country();
        var code = _faker.PickRandom(Country.CountryCodes.ToList());

        var country = new Country(name, code);

        country.Name.Should().Be(name);
        country.Code.Should().Be(code);
    }
}