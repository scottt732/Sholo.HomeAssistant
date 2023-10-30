using System;

namespace Sholo.HomeAssistant.Client.WebSockets.Events;

// TODO: Generate this code from RestClient.GetEventsAsync

[PublicAPI]
public static class EventTypesExtensions
{
    public static string AutomationTriggered([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string CallService([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string ComponentLoaded([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string CoreConfigUpdated([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string DeviceRegistryUpdated([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string EntityRegistryUpdated([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string HomeassistantClose([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string HomeassistantFinalWrite([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string HomeassistantStart([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string HomeassistantStop([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string LovelaceUpdated([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string PanelsUpdated([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string PersistentNotificationsUpdated([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string PlatformDiscovered([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string ScriptStarted([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string ServiceExecuted([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string ServiceRegistered([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string ServiceRemoved([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string StateChanged([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string ThemesUpdated([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string TimeChanged([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }

    public static string UserRemoved([NotNull] this IEventTypes eventTypes)
    {
        if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
        return EventTypes.FormatName();
    }
}
