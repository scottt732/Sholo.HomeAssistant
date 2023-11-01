// ReSharper disable once UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Local
namespace Sholo.HomeAssistant.Client.Http.Rest;

[PublicAPI]
internal static class RestClientUris
{
    public static readonly Uri IsEnabled = new(string.Empty, UriKind.Relative);
    public static readonly Uri Config = new("config", UriKind.Relative);
    public static readonly Uri Services = new("services", UriKind.Relative);
    public static readonly Uri ErrorLog = new("error_log", UriKind.Relative);
    public static readonly Uri Calendars = new("calendars", UriKind.Relative);
    public static readonly Uri States = new("states", UriKind.Relative);
    public static readonly Uri Events = new("events", UriKind.Relative);
    public static readonly Uri Template = new("template", UriKind.Relative);
    public static readonly Uri CheckConfig = new("config/core/check_config", UriKind.Relative);
    public static readonly Uri IntentHandle = new("intent/handle", UriKind.Relative);

    public static Uri History(string[]? entityIds = null, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null)
    {
        var filterSuffix = entityIds is { Length: > 0 }
            ? "filter_entity_id=" + string.Join(",", entityIds.Select(Uri.EscapeDataString))
            : null;

        // ReSharper disable ConditionIsAlwaysTrueOrFalse
        if (startTime.HasValue && endTime.HasValue)
        {
            var effectiveFilterSuffix = filterSuffix != null ? $"&{filterSuffix}" : string.Empty;
            return new Uri($"history/period/{startTime.Value:yyyy-MM-dd\\Thh:mm:sszzz}?end_time={endTime.Value:yyyy-MM-dd\\Thh:mm:sszzz}{effectiveFilterSuffix}", UriKind.Relative);
        }

        if (startTime.HasValue && !endTime.HasValue)
        {
            var effectiveFilterSuffix = filterSuffix != null ? $"?{filterSuffix}" : string.Empty;
            return new Uri($"history/period/{startTime.Value:yyyy-MM-dd\\Thh:mm:sszzz}{effectiveFilterSuffix}", UriKind.Relative);
        }

        if (!startTime.HasValue && endTime.HasValue)
        {
            var effectiveFilterSuffix = filterSuffix != null ? $"&{filterSuffix}" : string.Empty;
            return new Uri($"history/period/{DateTimeOffset.Now.AddDays(-1):yyyy-MM-dd\\Thh:mm:sszzz}?end_time={endTime.Value:yyyy-MM-dd\\Thh:mm:sszzz}{effectiveFilterSuffix}", UriKind.Relative);
        }

        if (!startTime.HasValue && !endTime.HasValue)
        {
            var effectiveFilterSuffix = filterSuffix != null ? $"?{filterSuffix}" : string.Empty;
            return new Uri($"history/period{effectiveFilterSuffix}", UriKind.Relative);
        }

        throw new InvalidOperationException("This is impossible");
    }

    public static Uri LogBook(DateTimeOffset? startTime = null, DateTimeOffset? endTime = null, string? entityId = null)
    {
        var filterSuffix = entityId != null
            ? "entity_id=" + Uri.EscapeDataString(entityId)
            : null;

        var effectiveFilterSuffix = filterSuffix != null ? $"&{filterSuffix}" : string.Empty;

        // ReSharper disable ConditionIsAlwaysTrueOrFalse
        if (startTime.HasValue && endTime.HasValue)
        {
            return new Uri($"logbook/{startTime.Value:yyyy-MM-dd\\Thh:mm:sszzz}?end_time={endTime.Value:yyyy-MM-dd\\Thh:mm:sszzz}{effectiveFilterSuffix}", UriKind.Relative);
        }

        if (startTime.HasValue && !endTime.HasValue)
        {
            return new Uri($"logbook/{startTime.Value:yyyy-MM-dd\\Thh:mm:sszzz}{effectiveFilterSuffix}", UriKind.Relative);
        }

        if (!startTime.HasValue && endTime.HasValue)
        {
            return new Uri($"logbook/{DateTimeOffset.Now.AddDays(-1):yyyy-MM-dd\\Thh:mm:sszzz}?end_time={endTime.Value:yyyy-MM-dd\\Thh:mm:sszzz}{effectiveFilterSuffix}", UriKind.Relative);
        }

        if (!startTime.HasValue && !endTime.HasValue)
        {
            return new Uri($"logbook{effectiveFilterSuffix}", UriKind.Relative);
        }

        throw new InvalidOperationException("This is impossible");
    }

    public static Uri CalendarEntity(string entityId) => new($"calendars/{Uri.EscapeDataString(entityId)}", UriKind.Relative);
    public static Uri StatesForEntity(string entityId) => new($"states/{Uri.EscapeDataString(entityId)}", UriKind.Relative);
    public static Uri CameraThumbnail(string entityId) => new($"camera_proxy/{(entityId.Contains('.', StringComparison.Ordinal) ? Uri.EscapeDataString(entityId) : Uri.EscapeDataString($"camera.{entityId}"))}", UriKind.Relative);
    public static Uri EventsOfType(string eventType) => new($"events/{Uri.EscapeDataString(eventType)}", UriKind.Relative);
    public static Uri Service(string domain, string service) => new($"services/{Uri.EscapeDataString(domain)}/{Uri.EscapeDataString(service)}", UriKind.Relative);
}
