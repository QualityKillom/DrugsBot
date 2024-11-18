using Domain.Entities;
using Domain.ValueObjects;
using Bogus;

namespace UnitTest.GenerateTest;

public class DrugStoreGenerator
{
    private static readonly Faker<DrugStore> _fakerDrugStore = new Faker<DrugStore>()
        .CustomInstantiator(d => new DrugStore(
            d.Random.String2(2,100),
            d.Random.Int(1,10),
            new Address(d.Address.StreetName(), d.Address.City(),d.Random.Int(1,10),d.Random.Int(10000,999999))
        ));

    public static DrugStore Generator()
    {
        return _fakerDrugStore.Generate();
    }
}