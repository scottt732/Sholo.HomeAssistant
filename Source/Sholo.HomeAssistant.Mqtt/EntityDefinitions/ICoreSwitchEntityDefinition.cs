using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions
{
    [PublicAPI]
    public interface ICoreSwitchEntityDefinition : IStatefulEntityDefinition
    {
        /// <summary>
        /// Gets the MQTT topic to publish commands to control the switch.
        /// </summary>
        string CommandTopic { get; }

        /// <summary>
        /// Gets a flag that defines if switch works in optimistic mode.
        /// </summary>
        bool? Optimistic { get; }
    }
}
