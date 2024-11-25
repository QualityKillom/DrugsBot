using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;

namespace UnitTest.NegativeTest.EntitiesTest.CountryTest;

public class CountryNegativeTest
{
    /// <summary>
    /// Негативные тесты для значимого объекта Country
    /// </summary>
    public static IEnumerable<object[]> TestCountryValidation = GenerateNegativeTest.GetCountryValidationExceptionsProperties();

    /// <summary>
    /// Проверка, что у значимого объекта Country выбрасывается ValidationException.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    [Theory]
    [MemberData(nameof(TestCountryValidation))]
    public void Add_Country_ThrowValidationException(string name, string code)
    {
        var action = () => new Country(name, code);

        action.Should().Throw<ValidationException>();
    }
}