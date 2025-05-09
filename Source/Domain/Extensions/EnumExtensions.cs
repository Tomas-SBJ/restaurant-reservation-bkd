using System.ComponentModel;
using System.Reflection;

namespace Domain.Extensions;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T value) where T : Enum
    {
        var description = value.ToString();

        var fieldInfo = value.GetType().GetField(value.ToString() ?? string.Empty);

        if (fieldInfo == null)
        {
            return description;
        }
        
        var attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();

        if (attribute is not null)
        {
            description = attribute.Description;
        }

        return description;
    }
}