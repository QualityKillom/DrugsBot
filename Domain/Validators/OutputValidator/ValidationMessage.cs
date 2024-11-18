
namespace Domain.Validators;

public class ValidationMessage
{
    public static string NotNull = "{PropertyName} cannot be null.";
    public static string NotEmpty = "{PropertyName} cannot be empty.";
    public static string WrongLenght = "{PropertyName} must be between {MinLength} and {MaxLength}.";
    public static string WrongText = "{PropertyName} the text contains invalid characters.";
    public static string CountryCodeInvalid = "{PropertyName} must exist in the country directory.";
    public static string WrongNumber = "{PropertyName} so big.";  
    public static string WrongCharacters = "{PropertyName} contains invalid characters.";
    public static string WrongPolarity = "{PropertyName} contains invalid polarity.";
}