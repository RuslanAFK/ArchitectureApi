namespace ArchitectureApi.Extensions;

public static class UserExtensions
{
    public static string Append(this string name, string? next)
    {
        if (next is null)
            return name;
        return name + " " + next;
    }
}