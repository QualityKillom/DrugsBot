using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;

namespace UnitTest.NegativeTest.EntitiesTest.DrugItemTest;

public class DrugItemNegativeTest
{
    /// <summary>
    /// Негативные тесты для значимого объекта DrugItem
    /// </summary>
    public static IEnumerable<object[]> TestDrugItemValidator = GenerateNegativeTest.GetDrugsItemValidationExceptionsProperties();

    /// <summary>
    /// Проверка, что у значимого объекта DrugItem выбрасывается ValidationException.
    /// </summary>
    /// <param name="drugId"></param>
    /// <param name="drugStoreId"></param>
    /// <param name="cost"></param>
    /// <param name="count"></param>
    /// <param name="drug"></param>
    /// <param name="drugStore"></param>
    [Theory]
    [MemberData(nameof(TestDrugItemValidator))]
    public void Add_DrugItem_ThrowValidationException(Guid drugId, Guid drugStoreId, decimal cost, int count, Drug drug, DrugStore drugStore)
    {
        var action = () => new DrugItem(drugId,drugStoreId,cost,count,drug,drugStore);

        action.Should().Throw<ValidationException>();
    }
    
}