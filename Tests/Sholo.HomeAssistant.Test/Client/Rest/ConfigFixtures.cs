using System;
using System.Globalization;
using System.Linq;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Events;

namespace Sholo.HomeAssistant.Test.Client.Rest;

public static class RestFixtures
{
    internal static class IsEnabled
    {
        public const string Json = @"{ ""message"": ""API running."" }";
    }

    internal static class Config
    {
        public const double Latitude = 20.62311404622752f;
        public const double Longitude = -20.27864241032167f;
        public const int Elevation = 10;

        public const string UnitSystemLength = "mi";
        public const string UnitSystemMass = "lb";
        public const string UnitSystemPressure = "psi";
        public const string UnitSystemTemperature = "°F";
        public const string UnitSystemVolume = "gal";
        public const string LocationName = "Unit Tests";
        public const string TimeZone = "America/New_York";
        public const string ConfigDir = "/config";

        public const string ConfigSource = "storage";
        public const bool SafeMode = false;
        public const string State = "RUNNING";
        public const string ExternalUrl = "https://external.myhouse.com";
        public const string InternalUrl = "http://192.168.1.1:8123";
        public const string Currency = "USD";

        public static readonly string[] WhitelistExternalDirs = new[] { "/media", "/config/www" };
        public static readonly string[] AllowlistExternalDirs = new[] { "/media", "/config/www" };

        public static readonly string[] AllowlistExternalUrls =
            new[] { "https://www.someserver.com", "https://www.someotherserver.com" };

        public static readonly string Version = DateTime.Now.ToString("yyyy.MM.d", CultureInfo.InvariantCulture);

        public static readonly string[] Components = new[]
        {
            "group",
            "system_health",
            "counter",
            "mqtt",
            "sensor",
            "usb",
            "zone",
            "logger",
            "search",
            "frontend",
            "stream",
            "media_source",
            "binary_sensor",
            "energy",
            "image",
            "onboarding",
            "http",
            "persistent_notification",
            "recorder",
            "history",
            "zeroconf",
            "auth",
            "sun",
            "homeassistant",
            "map",
            "input_datetime",
            "sensor.energy",
            "analytics",
            "timer",
            "binary_sensor.updater",
            "scene.homeassistant",
            "ssdp",
            "system_log",
            "notify",
            "input_select",
            "input_number",
            "automation",
            "input_text",
            "lovelace",
            "tts",
            "websocket_api",
            "input_boolean",
            "api",
            "mobile_app",
            "cloud",
            "webhook",
            "updater",
            "logbook",
            "my",
            "dhcp",
            "trace",
            "scene",
            "network",
            "default_config",
            "notify.mobile_app",
            "device_automation",
            "tag",
            "blueprint",
            "tts.google_translate",
            "script",
            "config",
            "person"
        };

        public static readonly string Json =
            @"{" +
            @$"  ""latitude"": {Latitude:F14}," +
            @$"  ""longitude"": {Longitude:F14}," +
            @$"  ""elevation"": {Elevation}," +
            @"  ""unit_system"": {" +
            @$"    ""length"": ""{UnitSystemLength}""," +
            @$"    ""mass"": ""{UnitSystemMass}""," +
            @$"    ""pressure"": ""{UnitSystemPressure}""," +
            @$"    ""temperature"": ""{UnitSystemTemperature}""," +
            @$"    ""volume"": ""{UnitSystemVolume}""" +
            @"  }," +
            @$"  ""location_name"": ""{LocationName}""," +
            @$"  ""time_zone"": ""{TimeZone}""," +
            @$"  ""components"": [ {string.Join(", ", Components.Select(x => $"\"{x}\""))} ]," +
            @$"  ""config_dir"": ""{ConfigDir}""," +
            @$"  ""whitelist_external_dirs"": [ {string.Join(", ", WhitelistExternalDirs.Select(x => $"\"{x}\""))} ]," +
            $@"  ""allowlist_external_dirs"": [ {string.Join(", ", AllowlistExternalDirs.Select(x => $"\"{x}\""))} ]," +
            $@"  ""allowlist_external_urls"": [ {string.Join(", ", AllowlistExternalUrls.Select(x => $"\"{x}\""))} ]," +
            $@"  ""version"": ""{Version}""," +
            $@"  ""config_source"": ""{ConfigSource}""," +
            $@"  ""safe_mode"": {SafeMode.ToString().ToLower(CultureInfo.CurrentCulture)}," +
            $@"  ""state"": ""{State}""," +
            $@"  ""external_url"": ""{ExternalUrl}""," +
            $@"  ""internal_url"": ""{InternalUrl}""," +
            $@"  ""currency"": ""{Currency}""" +
            @"}";
    }

    internal static class Events
    {
        public const string Json = @"[ { ""event"": ""state_changed"", ""listener_count"": 5 }, { ""event"": ""time_changed"", ""listener_count"": 2 } ]";

        public static readonly EventResult[] ExpectedEvents = new[]
        {
            new EventResult { Event = "state_changed", ListenerCount = 5 },
            new EventResult { Event = "time_changed", ListenerCount = 2 }
        };
    }
}
