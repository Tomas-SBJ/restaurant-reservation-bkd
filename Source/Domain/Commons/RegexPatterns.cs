using System.Text.RegularExpressions;

namespace Domain.Commons;

public static partial class RegexPatterns
{
    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled)]
    public static partial Regex EmailRegex();
    
    [GeneratedRegex("[A-Z]")]
    public static partial Regex AzRegex();
}