using System;

namespace Sholo.HomeAssistant.Settings
{
    public class HomeAssistantConnectionResiliencyOptions
    {
        public bool Enabled { get; set; } = true;
        public TimeSpan IntervalBetweenConnectionAttempts { get; set; } = TimeSpan.FromSeconds(5);
        public int? MaximumAttemptsBeforeFailure { get; set; }
    }
}
