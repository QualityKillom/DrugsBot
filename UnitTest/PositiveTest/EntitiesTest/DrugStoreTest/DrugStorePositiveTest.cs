using Domain.Entities;
using FluentAssertions;
using Address = Domain.ValueObjects.Address;

namespace UnitTest.PositiveTest.EntitiesTest.DrugStoreTest;

public class DrugStorePositiveTest
{
    private readonly Bogus.Faker _faker = new();

    [Fact]
    public void Add_Return_DrugStore()
    {
        var drugNetwork = _faker.Random.String2(2,100);
        var number = _faker.Random.Int(2,100);
        var address =  new Address(_faker.Address.City(), _faker.Address.StreetName(), _faker.Random.Int(2, 100), _faker.Random.Int(10000, 999999));
        
        
        var drugStore = new DrugStore(drugNetwork, number, address);
        
        drugStore.DrugNetwork.Should().Be(drugNetwork);
        drugStore.Number.Should().Be(number);
        drugStore.Address.Should().Be(address);
      
    }
}