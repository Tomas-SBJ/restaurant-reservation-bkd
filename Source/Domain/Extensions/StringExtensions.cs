using Domain.Commons;

namespace Domain.Extensions;

public static class StringExtensions
{
    public static string ReplaceWithAzRegex(this string input, string replacement)
    {
        return RegexPatterns.AzRegex().Replace(input, replacement).TrimStart();
    }
}