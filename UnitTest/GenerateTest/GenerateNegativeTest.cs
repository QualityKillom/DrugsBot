using Domain.Entities;
using Domain.ValueObjects;

namespace UnitTest.GenerateTest
{
    public class GenerateNegativeTest
    {
        private static readonly Bogus.Faker _faker = new();

        public static IEnumerable<object[]> GetAddressValidationExceptionsProperties()
        {
            return new List<object[]>
            {
                new object[] { null, _faker.Address.StreetName(), _faker.Random.Int(1, 10), _faker.Random.Int(10000, 999999) },
                new object[] { _faker.Address.City(), null, _faker.Random.Int(1, 10), _faker.Random.Int(10000, 999999) },
                new object[] { _faker.Address.City(), _faker.Address.StreetName(), null, _faker.Random.Int(10000, 999999) },
                new object[] { _faker.Address.City(), _faker.Address.StreetName(), _faker.Random.Int(1, 10),null }
            };
        }

        public static IEnumerable<object[]> GetCountryValidationExceptionsProperties()
        {
            return new List<object[]>
            {
                new object[] { null, _faker.PickRandom(Country.CountryCodes.ToList())},
                new object[] { _faker.Address.Country(), null }
            };
        }

        public static IEnumerable<object[]> GetDrugsValidationExceptionsProperties()
        {
            var country = CountryGenerator.Generator();
            return new List<object[]>
            {
                new object[] { null, _faker.Random.String2(2,100),country.Code,country},
                new object[] { _faker.Random.String2(2,150), null,country.Code,country },
                new object[] { _faker.Random.String2(2,28), _faker.Random.String2(2,100), null, country },
                new object[] { _faker.Random.String2(2,28), _faker.Random.String2(2,100),country.Code,null }
            };
        }

        public static IEnumerable<object[]> GetDrugsItemValidationExceptionsProperties()
        {
            var drugStore = DrugStoreGenerator.Generator();
            var drug = DrugGenerator.Generator();
            return new List<object[]>
            {
                new object[] {null,drugStore.Id, _faker.Random.Decimal(1), _faker.Random.Int(1, 100), drug,  drugStore },
                new object[] {drug.Id,null, _faker.Random.Decimal(1), _faker.Random.Int(1, 100), drug,  drugStore  },
                new object[] {drug.Id,drugStore.Id, -1, _faker.Random.Int(1, 100), drug,  drugStore  },
                new object[] {drug.Id,drugStore.Id, _faker.Random.Decimal(1),-1, drug,  drugStore  },
                new object[] {drug.Id,drugStore.Id, _faker.Random.Decimal(1), _faker.Random.Int(1, 100), null,  drugStore  },
                new object[] {drug.Id,drugStore.Id, _faker.Random.Decimal(1), _faker.Random.Int(1, 100), drug,  null  },

            };
        }

        public static IEnumerable<object[]> GetDrugStoreValidationExceptionsProperties()
        {
            var country = CountryGenerator.Generator();
            return new List<object[]>
            { 
                new object[] { null, _faker.Random.Int(1, 10), new Address(_faker.Address.StreetName(), _faker.Address.City(), _faker.Random.Int(1, 10), _faker.Random.Int(10000, 999999)) },
                new object[] { _faker.Random.String2(1, 10000), null, new Address(_faker.Address.StreetName(), _faker.Address.City(), _faker.Random.Int(1, 10), _faker.Random.Int(10000, 999999))},
                new object[] { _faker.Random.String2(1, 10000), _faker.Random.Int(1, 10), new Address(_faker.Address.StreetName(), _faker.Address.City(), _faker.Random.Int(1, 10), _faker.Random.Int(10000, 999999)) },
            };
        }
    }
}