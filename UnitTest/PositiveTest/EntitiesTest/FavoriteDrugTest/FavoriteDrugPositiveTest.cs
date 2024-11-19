using Domain.Entities;
using FluentAssertions;
using UnitTest.GenerateTest.EntitiesGenerator;

namespace UnitTest.PositiveTest.EntitiesTest.FavoriteDrugTest;

public class FavoriteDrugPositiveTest
{
    private readonly Bogus.Faker _faker = new();

    [Fact]
    public void Add_Return_FavoriteDrug()
    {
        var profile = ProfileGenerator.Generator();
        var drug = DrugGenerator.Generator();
        var drugStore = DrugStoreGenerator.Generator();
        var externalId = profile.Id;
        var drugId = drug.Id;
        var drugStoreId = drugStore.Id;

        var favoriteItem = new FavoriteDrug(profile, externalId, drugId, drug, drugStoreId, drugStore);
        
        favoriteItem.Profile.Should().Be(profile);
        favoriteItem.DrugStore.Should().Be(drugStore);
        favoriteItem.Drug.Should().Be(drug);
        favoriteItem.ExternalUserId.Should().Be(externalId);
        favoriteItem.DrugId.Should().Be(drugId);
        favoriteItem.DrugStoreId.Should().Be(drugStoreId);
    }
}