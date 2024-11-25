using Bogus;
using Domain.Entities;
using Domain.ValueObjects;

namespace UnitTest.GenerateTest.EntitiesGenerator;

/// <summary>
/// Генератор сущности Profile для тестов
/// </summary>
public class ProfileGenerator
{
    private static readonly Faker<Profile> _fakerProfile = new Faker<Profile>()
        .CustomInstantiator(p => new Profile(
            p.Random.AlphaNumeric(8),
                new Email(p.Internet.Email())
            ));

    /// <summary>
    /// Генератор профиля 
    /// </summary>
    /// <returns></returns>
        public static Profile Generator()
        {
            return _fakerProfile.Generate();
        }
}