using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;

namespace UnitTest.NegativeTest.EntitiesTest.DrugItemTest;

public class DrugItemNegativeTest
{
    public static IEnumerable<object[]> TestDrugItemValidator = GenerateNegativeTest.GetDrugsItemValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestDrugItemValidator))]
    public void Add_DrugItem_ThrowValidationException(Guid drugId, Guid drugStoreId, decimal cost, int count, Drug drug, DrugStore drugStore)
    {
        var action = () => new DrugItem(drugId,drugStoreId,cost,count,drug,drugStore);

        action.Should().Throw<ValidationException>();
    }
    
}