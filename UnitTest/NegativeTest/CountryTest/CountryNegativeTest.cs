using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;

namespace UnitTest.NegativeTest.CountryTest;

public class CountryNegativeTest
{
    public static IEnumerable<object[]> TestCountryValidation = GenerateNegativeTest.GetCountryValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestCountryValidation))]
    public void Add_Country_ThrowValidationException(string name, string code)
    {
        var action = () => new Country(name, code);

        action.Should().Throw<ValidationException>();
    }
}