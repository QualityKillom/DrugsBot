using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;

namespace UnitTest.NegativeTest.EntitiesTest.DrugStoreTest;

public class DrugStoreNegativeTest
{
    /// <summary>
    /// Негативные тесты для значимого объекта DrugStore
    /// </summary>
    public static IEnumerable<object[]> TestDrugStoreValidator = GenerateNegativeTest.GetDrugStoreValidationExceptionsProperties();

    /// <summary>
    /// Проверка, что у значимого объекта DrugStore выбрасывается ValidationException.
    /// </summary>
    /// <param name="drugNetwork"></param>
    /// <param name="number"></param>
    /// <param name="address"></param>
    [Theory]
    [MemberData(nameof(TestDrugStoreValidator))]
    public void Add_DrugItem_ThrowValidationException(string drugNetwork,int number, Address address)
    {
        var action = () => new DrugStore(drugNetwork,number,address);

        action.Should().Throw<ValidationException>();
    }
}