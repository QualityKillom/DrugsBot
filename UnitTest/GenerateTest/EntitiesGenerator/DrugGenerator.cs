using Bogus;
using Domain.Entities;

namespace UnitTest.GenerateTest.EntitiesGenerator;

public class DrugGenerator
{
    /// <summary>
    /// Генератор сущности Drug для тестов
    /// </summary>
    private static readonly Faker<Drug> _fakerDrug = new Faker<Drug>()
        .CustomInstantiator(d =>
        {
            var country = CountryGenerator.Generator();
            return new Drug(
                d.Random.String2(10),
                d.Random.String2(10),
                country.Code,
                country
            );
        });

    /// <summary>
    /// Генератор лекарства 
    /// </summary>
    /// <returns></returns>
    public static Drug Generator()
    {
        return _fakerDrug.Generate();
    }
}