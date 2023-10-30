using System;
using System.Runtime.CompilerServices;
using Sholo.HomeAssistant.Utilities;

namespace Sholo.HomeAssistant.Client.WebSockets.Events;

public class EventTypes : IEventTypes
{
    private static readonly Lazy<IEventTypes> InstanceFactory = new(() => new EventTypes());

    public static IEventTypes Instance => InstanceFactory.Value;

    private EventTypes()
    {
    }

    public static string FormatName([CallerMemberName] string? name = null)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (name.Length == 0)
        {
            throw new ArgumentException($"The {nameof(name)} argument cannot be empty", nameof(name));
        }

        return name.ToSnakeCase();
    }
}
