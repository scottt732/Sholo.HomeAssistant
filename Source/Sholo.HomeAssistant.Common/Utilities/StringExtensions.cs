using System;
using System.Globalization;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Utilities
{
    [PublicAPI]
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string str)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                if (i == 0)
                {
                    sb.Append(char.ToLower(str[0], CultureInfo.CurrentCulture));
                }
                else if (char.IsUpper(str[i]))
                {
                    sb.Append('_');
                    sb.Append(char.ToLower(str[i], CultureInfo.CurrentCulture));
                }
                else if (str[i] == ' ')
                {
                    sb.Append('_');
                }
                else if (char.IsLetterOrDigit(str[i]))
                {
                    sb.Append(str[i]);
                }
            }

            return sb.ToString();
        }

        public static string FromSnakeToPascalCase(this string str) => str.FromSnakeToPascalCase(out _);

        public static string FromSnakeToPascalCase(this string str, out bool requiresSerializationOverride)
        {
            requiresSerializationOverride = str.StartsWith("_", StringComparison.Ordinal)
                                            || str.EndsWith("_", StringComparison.Ordinal)
                                            || str.IndexOf(" ", StringComparison.Ordinal) >= 0
                                            || str.IndexOf("__", StringComparison.Ordinal) >= 0;

            return string.Join(string.Empty, str.Split('_', '.', ' ')
                .Select(x => x.Substring(0, Math.Min(1, x.Length)).ToUpper(CultureInfo.CurrentCulture) + (x.Length > 1 ? x.Substring(1) : string.Empty)));
        }

        public static string FromSnakeToTitleCase(this string str) => str.FromSnakeToTitleCase(out _);

        public static string FromSnakeToTitleCase(this string str, out bool requiresSerializationOverride)
        {
            requiresSerializationOverride = str.StartsWith("_", StringComparison.Ordinal)
                                            || str.EndsWith("_", StringComparison.Ordinal)
                                            || str.IndexOf(" ", StringComparison.Ordinal) >= 0
                                            || str.IndexOf("__", StringComparison.Ordinal) >= 0;

            return string.Join(" ", str.Split('_', '.', ' ').Select(x => x.Substring(0, Math.Min(1, x.Length)).ToUpper(CultureInfo.CurrentCulture) + (x.Length > 1 ? x.Substring(1) : string.Empty)));
        }
    }
}
