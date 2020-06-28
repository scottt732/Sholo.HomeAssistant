using System;

namespace Sholo.HomeAssistant.Client.Settings
{
    public class HomeAssistantClientOptions
    {
        public Uri ApiUrlPrefix { get; set; }
        public Uri WsUrl { get; set; }
        public HomeAssistantAuthOptions Auth { get; set; } = new HomeAssistantAuthOptions();
        public HomeAssistantHealthCheckOptions HealthChecks { get; set; } = new HomeAssistantHealthCheckOptions();
        public HomeAssistantConnectionResiliencyOptions ConnectionResiliency { get; set; } = new HomeAssistantConnectionResiliencyOptions();
    }
}