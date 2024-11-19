using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;
using UnitTest.GenerateTest.EntitiesGenerator;

namespace UnitTest.NegativeTest.EntitiesTest.FavoriteDrugTest;

public class FavoriteDrugNegativeTest
{
    public static IEnumerable<object[]> TestFavoriteDrugValidator = GenerateNegativeTest.GetFavoritesValidationExceptionsProperties();

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