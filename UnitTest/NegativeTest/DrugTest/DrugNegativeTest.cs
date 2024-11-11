using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;

namespace UnitTest.NegativeTest.DrugTest;

public class DrugNegativeTest
{
    public static IEnumerable<object[]> TestDrugValidator = GenerateNegativeTest.GetDrugsValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestDrugValidator))]
    public void Add_Drug_ThrowValidationException(string name, string manufacturer, string countryCodeId, Country country)
    {
        var action = () => new Drug(name, manufacturer, countryCodeId, country);

        action.Should().Throw<ValidationException>();
    }
}