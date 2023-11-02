namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public interface IButtonEntityDefinition : IStatefulEntityDefinition
{
    /// <summary>
    /// The template used for the command payload.
    /// </summary>
    string? CommandTemplate { get; }

    /// <summary>
    /// The MQTT topic to publish commands to trigger the button
    /// </summary>
    string CommandTopic { get; }

    ButtonDeviceClass? DeviceClass { get; }

    bool? EnabledByDefault { get; }
    string? Encoding { get; }
    string? EntityCategory { get; }
    string? Icon { get; }
    string? PayloadPress { get; }
}
