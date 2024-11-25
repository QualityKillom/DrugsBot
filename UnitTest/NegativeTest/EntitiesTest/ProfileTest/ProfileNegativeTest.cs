using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;

namespace UnitTest.NegativeTest.EntitiesTest.ProfileTest;

public class ProfileNegativeTest
{
    /// <summary>
    /// Негативные тесты для значимого объекта Profile
    /// </summary>
    public static IEnumerable<object[]> TestProfileValidator = GenerateNegativeTest.GetProfileValidationExceptionsProperties();

    /// <summary>
    /// Проверка, что у значимого объекта Profile выбрасывается ValidationException.
    /// </summary>
    /// <param name="externalId"></param>
    /// <param name="email"></param>
    [Theory]
    [MemberData(nameof(TestProfileValidator))]
    public void Add_Profile_ThrowValidationException(string externalId, Email email)
    {
        var action = () => new Profile(externalId,email);

        action.Should().Throw<ValidationException>();
    }
}