using System;
using System.Linq;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Utilities
{
    [PublicAPI]
    public static class IdentifierValidator
    {
        private static readonly char[] CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static readonly char[] LowercaseLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static readonly char[] Digits = "0123456789".ToCharArray();

        private static readonly char[] Hyphen =
        {
            '-'
        };

        private static readonly char[] Underscore =
        {
            '_'
        };

        private static readonly char[] ValidDiscoveryPrefixCharacters;
        private static readonly char[] ValidNodeIdCharacters;
        private static readonly char[] ValidObjectIdCharacters;

        static IdentifierValidator()
        {
            ValidDiscoveryPrefixCharacters // Guessing on this one.
                = ValidNodeIdCharacters
                    = CapitalLetters.Concat(LowercaseLetters).Concat(Digits).Concat(Hyphen).Concat(Underscore).ToArray();

            ValidObjectIdCharacters = CapitalLetters.Concat(LowercaseLetters).Concat(Digits).Concat(Hyphen).Concat(Underscore).Concat(new[] { '/' }).ToArray();
        }

        public static bool IsValidDiscoveryPrefix(string discoveryPrefixId) => discoveryPrefixId.All(c => ValidDiscoveryPrefixCharacters.Contains(c));
        public static bool IsValidNodeId(string nodeId) => nodeId.All(c => ValidNodeIdCharacters.Contains(c));
        public static bool IsValidObjectId(string objectId) => objectId.All(c => ValidObjectIdCharacters.Contains(c));

        public static void ValidateDiscoveryPrefix(string discoveryPrefix) => Validate(discoveryPrefix, nameof(discoveryPrefix), IsValidDiscoveryPrefix);
        public static void ValidateNodeId(string nodeId) => Validate(nodeId, nameof(nodeId), IsValidNodeId);
        public static void ValidateObjectId(string objectId) => Validate(objectId, nameof(objectId), IsValidObjectId);

        private static void Validate(string value, string parameterName, Func<string, bool> validator)
        {
            if (value == null) throw new ArgumentNullException(parameterName);
            if (value.Length == 0) throw new ArgumentException(parameterName);
            if (!validator(value)) throw new ArgumentException($"The {parameterName} is invalid", parameterName);
        }
    }
}
