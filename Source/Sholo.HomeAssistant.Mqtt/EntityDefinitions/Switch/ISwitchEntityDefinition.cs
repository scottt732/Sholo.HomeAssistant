namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch
{
    public interface ISwitchEntityDefinition : ICoreSwitchEntityDefinition
    {
        /// <summary>
        /// Icon for the switch.
        /// </summary>
        string Icon { get; }

        /// <summary>
        /// The payload that represents disabled state.
        /// </summary>
        string PayloadOff { get; }

        /// <summary>
        /// The payload that represents enabled state.
        /// </summary>
        string PayloadOn { get; }

        /// <summary>
        /// The payload that represents the off state.
        /// </summary>
        string StateOff { get; }

        /// <summary>
        /// The payload that represents the on state.
        /// </summary>
        string StateOn { get; }
    }
}