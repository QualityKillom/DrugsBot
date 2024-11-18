using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;

namespace UnitTest.NegativeTest.ProfileTest;

public class ProfileNegativeTest
{
    public static IEnumerable<object[]> TestProfileValidator = GenerateNegativeTest.GetProfileValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestProfileValidator))]
    public void Add_Profile_ThrowValidationException(string externalId, Email email)
    {
        var action = () => new Profile(externalId,email);

        action.Should().Throw<ValidationException>();
    }
}