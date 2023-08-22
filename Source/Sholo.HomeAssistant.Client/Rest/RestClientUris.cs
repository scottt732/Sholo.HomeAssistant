using System;

// ReSharper disable once UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Local
namespace Sholo.HomeAssistant.Client.Rest
{
    public static class RestClientUris
    {
        public static readonly Uri IsEnabled = new Uri(string.Empty, UriKind.Relative);
        public static readonly Uri Config = new Uri("config", UriKind.Relative);
        public static readonly Uri ErrorLog = new Uri("error_log", UriKind.Relative);
        public static readonly Uri Services = new Uri("services", UriKind.Relative);
        public static readonly Uri States = new Uri("states", UriKind.Relative);

        public static Uri History(string[] entityIds = null, DateTimeOffset? startTime = null, DateTimeOffset? endTime = null)
        {
            var filterSuffix = entityIds != null && entityIds.Length > 0
                ? "filter_entity_id=" + string.Join(",", entityIds)
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

        public static Uri StatesForEntity(string entityId) => new Uri($"states/{entityId}", UriKind.Relative);
        public static Uri CameraThumbnail(string entityId) => new Uri($"camera_proxy/{(entityId.Contains('.', StringComparison.Ordinal) ? entityId : $"camera.{entityId}")}", UriKind.Relative);
        public static Uri Events(string eventType = null) => eventType != null ? new Uri($"events/{eventType}", UriKind.Relative) : new Uri("events", UriKind.Relative);
    }
}
