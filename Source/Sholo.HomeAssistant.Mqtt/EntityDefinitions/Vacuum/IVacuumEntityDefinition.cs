using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Vacuum
{
    [PublicAPI]
    public interface IVacuumEntityDefinition : IStatefulEntityDefinition
    {
        /// <summary>
        /// The MQTT topic to publish commands to control the vacuum.
        /// </summary>
        string CommandTopic { get; }

        /// <summary>
        /// List of possible fan speeds for the vacuum.
        /// </summary>
        string[] FanSpeedList { get; }

        /// <summary>
        /// The payload to send to the command_topic to begin a spot cleaning cycle.
        /// </summary>
        string PayloadCleanSpot { get; }

        /// <summary>
        /// The payload to send to the command_topic to locate the vacuum (typically plays a song).
        /// </summary>
        string PayloadLocate { get; }

        /// <summary>
        /// The payload to send to the command_topic to pause the vacuum.
        /// </summary>
        string PayloadPause { get; }

        /// <summary>
        /// The payload to send to the command_topic to tell the vacuum to return to base.
        /// </summary>
        string PayloadReturnToBase { get; }

        /// <summary>
        /// The payload to send to the command_topic to begin the cleaning cycle.
        /// </summary>
        string PayloadStart { get; }

        /// <summary>
        /// The payload to send to the command_topic to stop cleaning.
        /// </summary>
        string PayloadStop { get; }

        /// <summary>
        /// The schema to use.
        /// </summary>
        string Schema { get; }

        /// <summary>
        /// The MQTT topic to publish custom commands to the vacuum.
        /// </summary>
        string SendCommandTopic { get; }

        /// <summary>
        /// The MQTT topic to publish commands to control the vacuum's fan speed.
        /// </summary>
        string SetFanSpeedTopic { get; }

        /// <summary>
        /// List of features that the vacuum supports (possible values are start, stop, pause,
        /// return_home, battery, status, locate, clean_spot, fan_speed, send_command).
        /// </summary>
        VacuumFeature[] SupportedFeatures { get; }
    }
}
