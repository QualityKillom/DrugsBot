namespace UnitTest.InvalidItem.InvalidEmails;

public class InvalidEmails
{
   public static readonly HashSet<string> invalidEmails = new()
    {
        "invalid-email",
        "test@",
        "user@.com",
        "no-domain@site",
        "user@site..com"
    };
}