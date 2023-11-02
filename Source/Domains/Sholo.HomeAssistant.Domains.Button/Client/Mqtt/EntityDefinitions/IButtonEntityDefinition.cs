namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public interface IButtonEntityDefinition : IStatefulEntityDefinition
{
    /// <summary>
    /// The template used for the command payload. Available variables: action and code.
    /// </summary>
    string? CommandTemplate { get; }

    /// <summary>
    /// The MQTT topic to publish commands to change the alarm state.
    /// </summary>
    string? CommandTopic { get; }

    ButtonDeviceClass? DeviceClass { get; }

    bool? EnabledByDefault { get; }
    string? Encoding { get; }
    string? EntityCategory { get; }
    string? Icon { get; }
    string? PayloadPress { get; }
}
