using System;

namespace Sholo.HomeAssistant.Settings;

[PublicAPI]
public class HomeAssistantClientOptions
{
    public Uri RestApiUrlPrefix { get; set; } = null!;
    public Uri WsUrl { get; set; } = null!;
    public HomeAssistantAuthOptions Auth { get; set; } = new();
    public HomeAssistantHealthCheckOptions HealthChecks { get; set; } = new();
    public HomeAssistantConnectionResiliencyOptions ConnectionResiliency { get; set; } = new();
}
