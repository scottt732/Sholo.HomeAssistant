using System;

namespace Sholo.HomeAssistant.Client.WebSockets.Events;

// TODO: Generate this code from RestClient.GetEventsAsync

[PublicAPI]
public static class EventTypesExtensions
{
    public static string AutomationTriggered(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string CallService(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string ComponentLoaded(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string CoreConfigUpdated(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string DeviceRegistryUpdated(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string EntityRegistryUpdated(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string HomeassistantClose(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string HomeassistantFinalWrite(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string HomeassistantStart(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string HomeassistantStop(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string LovelaceUpdated(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string PanelsUpdated(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string PersistentNotificationsUpdated(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string PlatformDiscovered(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string ScriptStarted(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string ServiceExecuted(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string ServiceRegistered(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string ServiceRemoved(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string StateChanged(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string ThemesUpdated(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string TimeChanged(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }

    public static string UserRemoved(this IEventTypes eventTypes)
    {
        ArgumentNullException.ThrowIfNull(eventTypes);
        return EventTypes.FormatName();
    }
}
