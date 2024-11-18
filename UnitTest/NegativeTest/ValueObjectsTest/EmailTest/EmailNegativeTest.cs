using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;

namespace UnitTest.NegativeTest.EmailTest;

public class EmailNegativeTest
{
    public static IEnumerable<object[]> TestEmailValidator = GenerateNegativeTest.GetEmailValidationExceptionsProperties();

    [Theory]
    [MemberData(nameof(TestEmailValidator))]
    public void Add_Email_ThrowValidationException(string valueEmail)
    {
        var action = () => new Email(valueEmail);

        action.Should().Throw<ValidationException>();
    }
}