using Domain.Entities;
using Domain.ValueObjects;
using UnitTest.GenerateTest.EntitiesGenerator;
using UnitTest.InvalidItem.InvalidEmails;

namespace UnitTest.GenerateTest
{
    public class GenerateNegativeTest
    {
        private static readonly Bogus.Faker _faker = new();
        
        /// <summary>
        /// Негативный генератор для тестов Validators сущности Address 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Негативный генератор для тестов Validators сущности Country 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetCountryValidationExceptionsProperties()
        {
            return new List<object[]>
            {
                new object[] { null, _faker.PickRandom(Country.CountryCodes.ToList())},
                new object[] { _faker.Address.Country(), null }
            };
        }

        /// <summary>
        /// Негативный генератор для тестов Validators сущности Drug 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Негативный генератор для тестов Validators сущности DrugsItem
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Негативный генератор для тестов Validators сущности DrugStore
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Негативный генератор для тестов Validators сущности Profile 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetProfileValidationExceptionsProperties()
        {
            return new List<object[]>
            {
                new object[]{null, new Email(_faker.Internet.Email())},
                new object[]{_faker.Random.AlphaNumeric(8), null},
            };
        }
        /// <summary>
        /// Негативный генератор для тестов Validators сущности Email 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetEmailValidationExceptionsProperties()
        {
            return new List<object[]>
            {
                new object[] {_faker.PickRandom(InvalidEmails.invalidEmails.ToList())},
                new object[]{null},
            };
        }

        /// <summary>
        /// Негативный генератор для тестов Validators сущности FavoritesDrug 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetFavoritesValidationExceptionsProperties()
        {
            var profile = ProfileGenerator.Generator();
            var drug = DrugGenerator.Generator();
        
            return new List<object[]>
            {
                new object[] {null, profile.Id, drug.Id, drug },
                new object[] {profile, null, drug.Id, drug },
                new object[] {profile, profile.Id, null, drug },
                new object[] {profile, profile.Id, drug.Id,null  },
            };
        }
    }
}