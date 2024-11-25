using Bogus;
using Domain.Entities;
using Domain.ValueObjects;

namespace UnitTest.GenerateTest.EntitiesGenerator;

/// <summary>
/// Генератор сущности DrugStore для тестов
/// </summary>
public class DrugStoreGenerator
{
    private static readonly Faker<DrugStore> _fakerDrugStore = new Faker<DrugStore>()
        .CustomInstantiator(d => new DrugStore(
            d.Random.String2(2,100),
            d.Random.Int(1,10),
            new Address(d.Address.StreetName(), d.Address.City(),d.Random.Int(1,10),d.Random.Int(10000,999999))
        ));
    
    /// <summary>
    /// Генератор магазина 
    /// </summary>
    /// <returns></returns>
    public static DrugStore Generator()
    {
        return _fakerDrugStore.Generate();
    }
}