using Domain.Entities;
using Domain.ValueObjects;
using FluentAssertions;

namespace UnitTest.PositiveTest.EntitiesTest.ProfileTest;

public class ProfilePositiveTest
{
    private readonly Bogus.Faker _faker = new();

    [Fact]
    public void Add_Return_Drug()
    {
        var externalId = _faker.Random.AlphaNumeric(8);
        var email = new Email(_faker.Internet.Email());
      
        var profile = new Profile(externalId, email);
      
        profile.ExternalId.Should().Be(externalId);
        profile.Email.Should().Be(email);
      
    }
}