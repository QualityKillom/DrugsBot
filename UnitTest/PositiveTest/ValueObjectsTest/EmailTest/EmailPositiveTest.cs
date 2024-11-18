using Domain.ValueObjects;
using FluentAssertions;

namespace UnitTest.PositiveTest.EmailTest;

public class EmailPositiveTest
{
    private readonly Bogus.Faker _faker = new();

    [Fact]
    public void Add_Return_Email()
    {
        var emailName = _faker.Internet.Email();
        
        var email = new Email(emailName);

        email.Value.Should().Be(emailName);
    }
}