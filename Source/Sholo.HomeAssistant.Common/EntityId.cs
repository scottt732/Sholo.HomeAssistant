using System;

namespace Sholo.HomeAssistant;

[PublicAPI]
public static class EntityId
{
    private static readonly char[] DomainSeparator = { '.' };

    public static (string Domain, string EntityIdSuffix) Split(string entityId)
    {
        var parts = entityId.Split(DomainSeparator);
        if (parts.Length != 2)
        {
            throw new ArgumentException($"Entity ID '{entityId}' has too many segments. Expecting 2");
        }

        return (parts[0], parts[1]);
    }

    public static string GetDomain(string entityId) => Split(entityId).Domain;
}
