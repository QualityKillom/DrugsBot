using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;

namespace UnitTest.NegativeTest.EntitiesTest.DrugTest;

public class DrugNegativeTest
{
    /// <summary>
    /// Негативные тесты для значимого объекта Drug
    /// </summary>
    public static IEnumerable<object[]> TestDrugValidator = GenerateNegativeTest.GetDrugsValidationExceptionsProperties();

    /// <summary>
    /// Проверка, что у значимого объекта Drug выбрасывается ValidationException.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="manufacturer"></param>
    /// <param name="countryCodeId"></param>
    /// <param name="country"></param>
    [Theory]
    [MemberData(nameof(TestDrugValidator))]
    public void Add_Drug_ThrowValidationException(string name, string manufacturer, string countryCodeId, Country country)
    {
        var action = () => new Drug(name, manufacturer, countryCodeId, country);

        action.Should().Throw<ValidationException>();
    }
}