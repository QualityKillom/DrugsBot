using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;
using UnitTest.GenerateTest.EntitiesGenerator;

namespace UnitTest.NegativeTest.EntitiesTest.FavoriteDrugTest;

public class FavoriteDrugNegativeTest
{/// <summary>
    /// Негативные тесты для значимого объекта FavoriteDrug
    /// </summary>
    public static IEnumerable<object[]> TestFavoriteDrugValidator = GenerateNegativeTest.GetFavoritesValidationExceptionsProperties();

    /// <summary>
    /// Проверка, что у значимого объекта FavoriteDrug выбрасывается ValidationException.
    /// </summary>
    /// <param name="profile"></param>
    /// <param name="externalUserId"></param>
    /// <param name="drugId"></param>
    /// <param name="drug"></param>
    [Theory]
    [MemberData(nameof(TestFavoriteDrugValidator))]
    public void Add_FavoriteDrug_ThrowValidationException(Profile profile, Guid externalUserId, Guid drugId, Drug drug)
    {
        var drugStore = DrugStoreGenerator.Generator();
        var drugStoreId = drugStore.Id;
        
        var action = () => new FavoriteDrug(profile, externalUserId,drugId,drug,drugStoreId,drugStore);

        action.Should().Throw<ValidationException>();
    }
}