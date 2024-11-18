using Domain.ValueObjects;
using FluentAssertions;
using FluentValidation;
using UnitTest.GenerateTest;

namespace UnitTest.NegativeTest.AddressTest;

public class AddressNegativeTest
{
    public static IEnumerable<object[]> TestAddressValidation = GenerateNegativeTest.GetAddressValidationExceptionsProperties();
    
    [Theory]
    [MemberData(nameof(TestAddressValidation))]
    public void Add_Address_ThrowValidationException(string city, string street,int house,int postalCode)
    {
        var action = () => new Address(street,city,house,postalCode);
        
        action.Should().Throw<ValidationException>();
    }
    
}