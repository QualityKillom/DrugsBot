using Bogus;
using Domain.Entities;

namespace UnitTest.GenerateTest;

public class DrugGenerator
{
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

    public static Drug Generator()
    {
        return _fakerDrug.Generate();
    }
}