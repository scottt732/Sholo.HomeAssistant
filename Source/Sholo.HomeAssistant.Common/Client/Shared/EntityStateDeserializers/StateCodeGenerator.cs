using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Sholo.HomeAssistant.Client.Shared.EntityStates;
using Sholo.HomeAssistant.StateDeserializers;
using Sholo.HomeAssistant.Utilities;

namespace Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

[PublicAPI]
public class StateCodeGenerator : IStateCodeGenerator
{
    private IDictionary<string, ISet<string>> DomainsStates { get; } = new Dictionary<string, ISet<string>>();
    private IDictionary<string, IDictionary<string, IDictionary<string, int>>> DomainAttributeCounts { get; } = new Dictionary<string, IDictionary<string, IDictionary<string, int>>>();
    private IDictionary<string, ISet<string>> DomainAttributeNullability { get; } = new Dictionary<string, ISet<string>>();

    private static readonly object LockObject = new();

    public void Observe(string entityId, object? state, IDictionary<string, object> attributes)
    {
        lock (LockObject)
        {
            var entityDomain = GetDomainFromEntity(entityId);

            if (state != null)
            {
                if (!DomainsStates.TryGetValue(entityDomain, out var domainStates))
                {
                    DomainsStates[entityDomain] = domainStates = new HashSet<string>();
                }

                domainStates.Add(state.ToString()!);
            }

            if (!DomainAttributeCounts.TryGetValue(entityDomain, out var allAttributes))
            {
                DomainAttributeCounts[entityDomain] = allAttributes = new Dictionary<string, IDictionary<string, int>>();
            }

            foreach (var attribute in attributes)
            {
                var key = attribute.Key;
                var value = attribute.Value;

                if (!allAttributes.TryGetValue(key, out var values))
                {
                    allAttributes[key] = values = new Dictionary<string, int>();
                }

                if (value != null)
                {
                    var s = value.ToString() ?? throw new InvalidOperationException();
                    values.TryGetValue(s, out var currentCount);
                    values[s] = currentCount + 1;
                }
                else
                {
                    if (!DomainAttributeNullability.TryGetValue(entityDomain, out var attributeNullability))
                    {
                        DomainAttributeNullability[entityDomain] = attributeNullability = new HashSet<string>();
                    }

                    attributeNullability.Add(key);
                }
            }
        }
    }

#pragma warning disable CA1305 // Specify IFormatProvider
    public string GenerateCode()
    {
        var sb = new StringBuilder();
        var entityStateDeserializers = new List<string>();

        foreach (var domainAttributes in DomainAttributeCounts)
        {
            var domain = domainAttributes.Key;
            var attributes = domainAttributes.Value;

            var domainClassPrefix = domain.FromSnakeToPascalCase();

            DomainAttributeNullability.TryGetValue(domain, out var nullableAttributes);

            sb.AppendLine($"    public class {domainClassPrefix}StateAttributes");
            sb.AppendLine(@"    {");
            var first = true;

            var totalAttributeObservations = attributes.Values.SelectMany(x => x).Max(x => x.Value);

            foreach (var attributeValues in attributes)
            {
                var attribute = attributeValues.Key;
                var values = attributeValues.Value;

                var attributeName = attribute.FromSnakeToPascalCase(out var requiresSerializationOverride);
                var isNullable = nullableAttributes?.Contains(attribute) ?? false;
                var attributeType = GetBestType(values, totalAttributeObservations, isNullable, false, null, out _);

                if (requiresSerializationOverride)
                {
                    if (!first)
                    {
                        sb.AppendLine();
                    }

                    sb.AppendLine($"        [JsonProperty(\"{attribute}\")]");
                    sb.AppendLine($"        public {attributeType} {attributeName} {{ get; set; }}");
                }
                else
                {
                    sb.AppendLine($"        public {attributeType} {attributeName} {{ get; set; }}");
                }

                first = false;
            }

            sb.AppendLine(@"    }");
            sb.AppendLine();

            var domainHasStates = DomainsStates.TryGetValue(domain, out var states);
            if (domainHasStates)
            {
                var statesWithFakeObservations = states!.ToDictionary(x => x, _ => totalAttributeObservations);
                var stateType = GetBestType(statesWithFakeObservations, totalAttributeObservations, false, true, domainClassPrefix, out var isEnum);
                if (isEnum)
                {
                    sb.AppendLine($"    public enum {domainClassPrefix}StateValue");
                    sb.AppendLine(@"    {");
                    sb.AppendLine(@"        Unavailable,");

                    for (var idx = 0; idx < states!.ToArray().Length; idx++)
                    {
                        var value = states!.ToArray()[idx];
                        if (value == "unavailable")
                        {
                            continue;
                        }

                        var valueFormat = value.FromSnakeToPascalCase(out var requiresSerializationOverride);
                        if (requiresSerializationOverride)
                        {
                            sb.AppendLine();
                            sb.AppendLine($"        [EnumMember(Value = \"{value}\")]");
                            sb.AppendLine($"        {valueFormat}{(idx < states!.Count - 1 ? "," : string.Empty)}");
                        }
                        else
                        {
                            sb.AppendLine($"        {valueFormat}{(idx < states!.Count - 1 ? "," : string.Empty)}");
                        }
                    }

                    sb.AppendLine(@"    }");
                    sb.AppendLine();

                    sb.AppendLine($"    public class {domainClassPrefix}EntityState : {nameof(IEntityState)}<{domainClassPrefix}StateValue, {domainClassPrefix}StateAttributes>");
                    sb.AppendLine(@"    {");
                    sb.AppendLine(@"    }");
                }
                else
                {
                    sb.AppendLine($"    public class {domainClassPrefix}EntityState : {nameof(IEntityState)}<{stateType}, {domainClassPrefix}StateAttributes>");
                    sb.AppendLine(@"    {");
                    sb.AppendLine(@"    }");
                }
            }
            else
            {
                sb.AppendLine($"    public class {domainClassPrefix}EntityState : {nameof(IEntityState)}<{domainClassPrefix}StateAttributes>");
                sb.AppendLine(@"    {");
                sb.AppendLine(@"    }");
            }

            sb.AppendLine();
            sb.AppendLine($"    public class {domainClassPrefix}EntityStateDeserializer : BaseStateDeserializer<{domainClassPrefix}EntityState>");
            sb.AppendLine(@"    {");
            sb.AppendLine($"        public override string TargetDomain {{ get; }} = \"{domain}\";");
            sb.AppendLine(@"        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;");
            sb.AppendLine(@"    }");

            entityStateDeserializers.Add($"{domainClassPrefix}EntityStateDeserializer");
            sb.AppendLine();
        }

        sb.AppendLine(@"    public static class HomeAssistantClientConfigurationBuilderExtensions");
        sb.AppendLine(@"    {");
        sb.AppendLine(@"        public static IHomeAssistantClientConfigurationBuilder WithStateCodeGenerator(this IHomeAssistantClientConfigurationBuilder configurationBuilder)");
        sb.AppendLine(@"        {");
        if (entityStateDeserializers.Count > 0)
        {
            sb.AppendLine(@"            return configurationBuilder");
            for (var idx = 0; idx < entityStateDeserializers.Count; idx++)
            {
                var entityState = entityStateDeserializers[idx];
                sb.AppendLine($"                .WithStateDeserializer<{entityState}>(){(idx == entityStateDeserializers.Count - 1 ? ";" : string.Empty)}");
            }
        }
        else
        {
            sb.AppendLine(@"            return configurationBuilder;");
        }

        sb.AppendLine(@"        }");
        sb.AppendLine(@"    }");

        return sb.ToString();
    }
#pragma warning restore CA1305 // Specify IFormatProvider

    private static readonly (Func<string, bool> test, string targetType)[] Evaluators =
    {
        (s => int.TryParse(s, out _), "int"),
        (s => long.TryParse(s, out _), "long"),
        (s => double.TryParse(s, out _), "double"),
        (s => bool.TryParse(s, out _), "bool"),
        (_ => true, "string")
    };

    private string GetBestType(IDictionary<string, int> observedValues, int totalAttributeObservations, bool isNullable, bool isState, string? domainClassPrefix, out bool isEnum)
    {
        if (observedValues.Count == 0)
        {
            isEnum = false;
            return "string /* Ambiguous */";
        }

        isEnum = false;

        if (observedValues.Keys.All(x => x.StartsWith("[", StringComparison.Ordinal) && x.EndsWith("]", StringComparison.Ordinal)))
        {
            try
            {
                var arrayValues = observedValues.Keys
                    .SelectMany(JArray.Parse)
                    .Select(x => x.Value<string>()!)
                    .GroupBy(x => x)
                    .ToDictionary(
                        x => x.Key,
                        _ => totalAttributeObservations);

                var arrayItemType = GetBestType(arrayValues, totalAttributeObservations, isNullable, isState, domainClassPrefix, out isEnum);
                return $"{arrayItemType}[]";
            }
            catch
            {
                return "object[] /* ambiguous */";
            }
        }

        foreach (var (test, targetType) in Evaluators)
        {
            if (observedValues.All(v => test(v.Key)))
            {
                if (observedValues.Min(x => x.Value) < totalAttributeObservations)
                {
                    isNullable = true;
                }

                if (targetType == "string")
                {
                    // TODO: Configurable?
                    if (isState && observedValues.Count < 10)
                    {
                        isEnum = true;
                        return $"{domainClassPrefix}StateValue";
                    }
                    else
                    {
                        return "string";
                    }
                }
                else if (isNullable)
                {
                    return $"{targetType}?";
                }
                else
                {
                    return targetType;
                }
            }
        }

        return "object"; // TODO?
    }

    private string GetDomainFromEntity(string entityId) => entityId.Split(new[] { '.' }, 2).First();
}
