using System;

namespace Sholo.HomeAssistant.Settings
{
    public class HomeAssistantHealthCheckOptions
    {
        public bool Enabled { get; set; } = true;
        public TimeSpan HealthCheckInterval { get; set; } = TimeSpan.FromSeconds(15);
        public TimeSpan HealthCheckTimeout { get; set; } = TimeSpan.FromSeconds(5);
        public int ConsecutiveFailuresBeforeFailureAction { get; } = 5;
        public ConsecutiveHealthCheckFailureAction ConsecutiveHealthCheckFailureAction { get; set; } = ConsecutiveHealthCheckFailureAction.Reconnect;
    }
}
