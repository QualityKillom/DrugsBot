using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;

namespace UnitTest.NegativeTest.EntitiesTest.DrugStoreTest;

public class DrugStoreNegativeTest
{
    public static IEnumerable<object[]> TestDrugStoreValidator = GenerateNegativeTest.GetDrugStoreValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestDrugStoreValidator))]
    public void Add_DrugItem_ThrowValidationException(string drugNetwork,int number, Address address)
    {
        var action = () => new DrugStore(drugNetwork,number,address);

        action.Should().Throw<ValidationException>();
    }
}