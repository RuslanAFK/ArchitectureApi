namespace ArchitectureApi.Extensions;

public static class UserExtensions
{
    public static string AppendLastName(this string firstName, string lastName)
    {
        return firstName + " " + lastName;
    }
}