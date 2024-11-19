using Domain.Entities;
using FluentAssertions;
using UnitTest.GenerateTest;
using UnitTest.GenerateTest.EntitiesGenerator;

namespace UnitTest.PositiveTest.EntitiesTest.DrugItemTest;

public class DrugItemPositiveTest
{
    private readonly Bogus.Faker _faker = new();

    [Fact]
    public void Add_Return_DrugItem()
    {
        var drug = DrugGenerator.Generator();
        var drugStore = DrugStoreGenerator.Generator();
        var drugId = drug.Id;
        var drugStoreId = drugStore.Id;
        var cost = Math.Round(_faker.Random.Decimal(1, 10), 2);
        var count = _faker.Random.Int(1,100);
        
        var drugItem = new DrugItem(drugId,drugStoreId,cost,count,drug,drugStore);

        drugItem.DrugId.Should().Be(drugId);
        drugItem.Drug.Should().Be(drug);
        drugItem.DrugStoreId.Should().Be(drugStoreId);
        drugItem.DrugStore.Should().Be(drugStore);
        drugItem.Cost.Should().Be(cost);
        drugItem.Count.Should().Be(count);
    }
}